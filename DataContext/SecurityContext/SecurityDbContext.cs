using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DataContext.SecurityContext
{

    public class SecurityDbContext : IdentityDbContext
    {

        public SecurityDbContext() {}
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=.;Database=EventPlannerCasusSecurity;Trusted_Connection=True;TrustServerCertificate=True");

        }

    }

}
