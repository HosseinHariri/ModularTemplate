using ModularTemplate.Data.DBContext;
using ModularTemplate.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModularTemplate.Application.Customers.GetList
{
    public class GetCustomersHandler : IGetCustomersHandler
    {
        private readonly AppDbContext appDbContext;

        public GetCustomersHandler(AppDbContext commandDbContext)
        {
            appDbContext = commandDbContext ?? throw new ArgumentNullException(nameof(commandDbContext));
        }

        public IResponse<ICollection<GetCustomersVm>> Handle()
        {
            var viewModels = appDbContext.Customers.Select(x => new GetCustomersVm
            {
                BankAccountNumber = x.BankAccountNumber,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                FirstName = x.FirstName,
                Id = x.Id,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
            }).ToList();

            return ResponseFactory.Success(viewModels);
        }
    }
}