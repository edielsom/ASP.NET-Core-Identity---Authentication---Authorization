using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityManager
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .ToTable("AspNetUsuario");

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("Id")
                .HasColumnType("nvarchar(450)");

            builder
                .Property(c => c.UserName)
                .HasColumnName("NomeUsuario")
                .HasColumnType("nvarchar(256)");

            builder
                .Property(c => c.NormalizedUserName)
                .HasColumnName("NomeUsuarioNormal")
                .HasColumnType("nvarchar(256)");

            builder
                .Property(c => c.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar(256)");

            builder
                .Property(c => c.NormalizedEmail)
                .HasColumnName("EmailNormal")
                .HasColumnType("nvarchar(256)");


            builder
                .Property(c => c.EmailConfirmed)
                .HasColumnName("EmailConfirmado")
                .HasColumnType("bit")
                .IsRequired();

            builder
                .Property(c => c.PasswordHash)
                .HasColumnName("SenhaHash")
                .HasColumnType("nvarchar(max)");

            builder
                .Property(c => c.SecurityStamp)
                .HasColumnName("SeloSeguranca")
                .HasColumnType("nvarchar(max)");

            builder
                .Property(c => c.ConcurrencyStamp)
                .HasColumnName("SeloSimultanidade")
                .HasColumnType("nvarchar(max)");

            builder
               .Property(c => c.PhoneNumber)
               .HasColumnName("Telefone")
               .HasColumnType("nvarchar(20)");

            builder
               .Property(c => c.PhoneNumberConfirmed)
               .HasColumnName("TelefoneConfirmado")
               .HasColumnType("bit")
               .IsRequired();

            builder
               .Property(c => c.Celular)
               .HasColumnName("Celular")
               .HasColumnType("nvarchar(20)");

            builder
               .Property(c => c.TwoFactorEnabled)
               .HasColumnName("TwoFactorEnabled")
               .HasColumnType("bit")
               .IsRequired();

            builder
               .Property(c => c.LockoutEnd)
               .HasColumnName("FimBloqueio")
               .HasColumnType("datetimeoffset(7)");

            builder
              .Property(c => c.TwoFactorEnabled)
              .HasColumnName("BloqueioLigado")
              .HasColumnType("bit")
              .IsRequired();

            builder
              .Property(c => c.AccessFailedCount)
              .HasColumnName("QuantidadeAcessoFalhado")
              .HasColumnType("int")
              .IsRequired();
        }
    }
}
