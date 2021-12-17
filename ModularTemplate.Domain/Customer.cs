using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModularTemplate.Domain
{
    [Table(nameof(Customer))]
    public class Customer
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