using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityManager 
{
    public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder
                .ToTable("AspNetUsuarioLogin");

            builder
                .HasKey(d => new { d.LoginProvider, d.ProviderKey });

            builder
                .Property(d => d.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.ProviderKey)
               .HasColumnName("ProviderSenha")
               .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.ProviderDisplayName)
               .HasColumnName("NomeProvedor")
               .HasColumnType("nvarchar(max)");

            builder
               .Property(d => d.UserId)
               .HasColumnName("UsuarioId")
               .HasColumnType("nvarchar(450)");


        }
    }
}
