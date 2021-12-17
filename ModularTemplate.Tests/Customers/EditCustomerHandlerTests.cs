using ModularTemplate.Data;
using ModularTemplate.Data.DBContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ModularTemplate.BddTdd.Tests.Customers
{
    [TestClass()]
    public class EditCustomerHandlerTests
    {
        private AppDbContext appDbContext;

        [TestInitialize]
        public void Initialize()
        {
            appDbContext = new DbContextFactory().GetCommandContext();
        }
    }
}