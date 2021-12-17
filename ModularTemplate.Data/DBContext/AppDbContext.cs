using ModularTemplate.Domain;
using Microsoft.EntityFrameworkCore;

namespace ModularTemplate.Data.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}