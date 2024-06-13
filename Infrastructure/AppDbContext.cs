using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using eShop.MetallFactorUI.Model;

namespace MetallFactorUI.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<WorkRequest> WorkRequests { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity properties here if needed
        }
    }
}
