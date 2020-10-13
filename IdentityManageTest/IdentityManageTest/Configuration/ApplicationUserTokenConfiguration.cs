using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager 
{
    public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder
                .ToTable("AspNetUsuarioToken");

            builder
                .HasKey(d => new { d.UserId, d.LoginProvider, d.Name });

            builder
                .Property(d => d.UserId)
                .HasColumnName("UsuarioId")
                .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.LoginProvider)
               .HasColumnName("LoginProvider")
               .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.Name)
               .HasColumnName("Nome")
               .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.Value)
               .HasColumnName("Valor")
               .HasColumnType("nvarchar(max)");


        }
    }
}