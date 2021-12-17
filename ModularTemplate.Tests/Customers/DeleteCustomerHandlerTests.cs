using ModularTemplate.Data;
using ModularTemplate.Data.DBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModularTemplate.BddTdd.Tests.Customers
{
    [TestClass()]
    public class DeleteCustomerHandlerTests
    {
        private AppDbContext appDbContext;

        [TestInitialize]
        public void Initialize()
        {
            appDbContext = new DbContextFactory().GetCommandContext();
        }
    }
}