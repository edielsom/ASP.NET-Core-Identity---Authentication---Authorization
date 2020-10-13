using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager
{
    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder
                .ToTable("AspNetPapel");

            //builder
            //    .HasKey(d => d.Id);

            builder
                .Property(d => d.Id)
                .HasColumnName("Id")
                .HasColumnType("nvarchar(450)");

            builder
               .Property(d => d.NormalizedName)
               .HasColumnName("NomePapel")
               .HasColumnType("nvarchar(256)");

            builder
               .Property(d => d.ConcurrencyStamp)
               .HasColumnName("SeloSimultaniedade")
               .HasColumnType("nvarchar(max)");

 
        }
    }
}
