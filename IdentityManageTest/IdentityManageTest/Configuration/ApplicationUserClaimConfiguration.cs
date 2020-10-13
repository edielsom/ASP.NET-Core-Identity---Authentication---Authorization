using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityManager 
{
    public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder
                .ToTable("AspNetUsuarioPermissao");

            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                 .Property(d => d.UserId)
                 .HasColumnName("UsuarioId")
                 .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.ClaimType)
               .HasColumnName("TipoPermissao")
               .HasColumnType("nvarchar(max)");

            builder
               .Property(d => d.ClaimValue)
               .HasColumnName("ValorPermissao")
               .HasColumnType("nvarchar(max)");




        }
    }
}
