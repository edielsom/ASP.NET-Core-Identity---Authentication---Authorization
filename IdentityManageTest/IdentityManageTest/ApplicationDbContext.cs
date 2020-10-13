using IdentityManager ;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityManager
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ApplicationRoleClaim> ApplicationRoleClaim { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUserClaim> ApplicationUserClaim { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserLogin> ApplicationUserLogin { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationRoleClaimConfiguration());
            builder.ApplyConfiguration(new ApplicationRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserClaimConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ApplicationUserLoginConfiguration());
            builder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserTokenConfiguration());

        }
    }
}
 