using ModularTemplate.Application.Customers.GetList;
using ModularTemplate.Data;
using ModularTemplate.Data.DBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModularTemplate.BddTdd.Tests.Customers
{
    [TestClass()]
    public class GetCustomerHandlerTests
    {
        private AppDbContext appDbContext;

        [TestInitialize]
        public void Initialize()
        {
            appDbContext = new DbContextFactory().GetCommandContext();
        }

        [TestMethod]
        public void GetCustomerList_ReturnsSuccess()
        {
            var response = new GetCustomersHandler(appDbContext).Handle();

            Assert.IsNotNull(response.Data);
        }
    }
}