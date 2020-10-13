using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityManager 
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder
                .ToTable("AspNetUsuarioPapel");

            builder
                .HasKey(d => new { d.UserId,d.RoleId});

            builder
                .Property(d => d.UserId)
                .HasColumnName("UsuarioId")
                .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.RoleId)
               .HasColumnName("PapelId")
               .HasColumnType("nvarchar(450)");
        }
    }
}