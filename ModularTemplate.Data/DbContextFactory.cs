using ModularTemplate.Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace ModularTemplate.Data
{
    public class DbContextFactory
    {
        protected readonly AppDbContext appDbContext;

        public AppDbContext GetCommandContext()
        {
            var cnn = "Data Source=.;Initial Catalog=ModularTemplate;Integrated Security=True";

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(cnn)
                .Options;

            return new AppDbContext(options);
        }
    }
}
