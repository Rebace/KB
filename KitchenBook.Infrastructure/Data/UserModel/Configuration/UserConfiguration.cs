using KitchenBook.Domain;
using KitchenBook.Domain.UserModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenBook.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Token);
            builder.Property(x => x.Login).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
