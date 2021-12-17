using System;

namespace ModularTemplate.Application.Customers.Create
{
    public class CreateCustomerParam
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BankAccountNumber { get; set; }
    }
}