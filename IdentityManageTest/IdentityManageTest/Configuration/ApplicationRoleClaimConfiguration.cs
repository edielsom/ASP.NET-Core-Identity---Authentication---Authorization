using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IdentityManager 
{
    public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder
               .ToTable("AspNetPapelPermissao");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("int");

            builder
                .Property(c => c.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("nvarchar(450)")
                .IsRequired();

            builder
                .Property(c => c.ClaimType)
                .HasColumnName("TipoPermissao")
                .HasColumnType("nvarchar(MAX)");

            builder
                .Property(c => c.ClaimValue)
                .HasColumnName("ValorPermissao")
                .HasColumnType("nvarchar(MAX)");
        }
    }
}
