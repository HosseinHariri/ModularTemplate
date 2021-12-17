using System;

namespace ModularTemplate.Application.Customers.GetList
{
    public class GetCustomersVm
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; }

        public string BankAccountNumber { get; set; }
    }
}