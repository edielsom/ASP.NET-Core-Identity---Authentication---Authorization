using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
 