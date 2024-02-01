using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.DataContext.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        
        public DbSet<Models.Activity>? Activities { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<EventType>? EventTypes { get; set; }

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.;Database=EventPlannerCasusData;Trusted_Connection=True;TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

    }

}
