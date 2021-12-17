using ModularTemplate.Application.Customers.Create;
using ModularTemplate.Data;
using ModularTemplate.Data.DBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModularTemplate.BddTdd.Tests.Customers
{
    [TestClass()]
    public class CreateCustomerHandlerTests
    {
        private AppDbContext appDbContext;

        [TestInitialize]
        public void Initialize()
        {
            appDbContext = new DbContextFactory().GetCommandContext();
        }

        [TestMethod]
        public void CreateCustomer_ValidData_ReturnsSuccess()
        {
            var request = new CreateCustomerParam
            {
                FirstName = "aa",
                LastName = "ss",
                Email = "aa.bb.11@gmail.com",
                PhoneNumber = 989125597150,
                BankAccountNumber = "326598",
                DateOfBirth = new System.DateTime(1850, 2, 3)
            };

            var response = new CreateCustomerHandler(appDbContext).Handle(request);

            Assert.AreNotEqual(response.Data.Id, 0);
        }

        [TestMethod]
        public void CreateCustomer_NotValidPhone_ReturnsException()
        {
            // Todo: Refer to readme.md 

        }
    }
}