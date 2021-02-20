using Lab1.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab1.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(userEntity => userEntity.Id);
            builder.Property(userEntity => userEntity.Id).ValueGeneratedOnAdd();

            builder.Property(userEntity => userEntity.Login)
                .IsRequired()
                .HasMaxLength(320);
            builder.Property(userEntity => userEntity.PasswordHash)
                .IsRequired();
        }
    }
}
