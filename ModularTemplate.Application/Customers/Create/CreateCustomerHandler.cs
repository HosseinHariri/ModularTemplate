using ModularTemplate.Data.DBContext;
using ModularTemplate.Domain;
using ModularTemplate.Framework;
using PhoneNumbers;
using System;

namespace ModularTemplate.Application.Customers.Create
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        private readonly AppDbContext appDbContext;

        public CreateCustomerHandler(AppDbContext commandDbContext)
        {
            this.appDbContext = commandDbContext ?? throw new System.ArgumentNullException(nameof(commandDbContext));
        }

        public IResponse<CreateCustomerVm> Handle(CreateCustomerParam param)
        {
            IsValidEmail(param.Email);

            string countryCode = "IR";

            var customer = new Customer
            {
                BankAccountNumber = param.BankAccountNumber,
                DateOfBirth = param.DateOfBirth,
                Email = param.Email,
                FirstName = param.FirstName,
                LastName = param.LastName,
            };

            customer.PhoneNumber = ValidPhoneNumber(param.PhoneNumber, countryCode);

            appDbContext.Customers.Add(customer);
            appDbContext.SaveChanges();

            var viewModel = new CreateCustomerVm
            {
                Id = customer.Id
            };

            return ResponseFactory.Success(viewModel);
        }

        private ulong ValidPhoneNumber(ulong phone, string countryCode)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

            string telephoneNumber = phone.ToString();
            var phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

            bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
            if (!isValidNumber)
                throw new BadRequestException("IsNotValidNumber");

            bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode);
            if (!isValidRegion)
                throw new BadRequestException("IsNotValidRegion");

            var numberType = phoneUtil.GetNumberType(phoneNumber);

            string phoneNumberType = numberType.ToString();

            if (string.IsNullOrEmpty(phoneNumberType) || phoneNumberType != "MOBILE")
                throw new BadRequestException("IsNotMOBILE");

            var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164);

            return Convert.ToUInt64(originalNumber);
        }

        private bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
                throw new BadRequestException("IsNotValidEmail");

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                throw new BadRequestException("IsNotValidEmail");
            }
        }
    }
}