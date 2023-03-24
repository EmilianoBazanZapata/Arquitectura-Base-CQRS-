using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
            new ApplicationUser
            {
                Id = "d735fa86-1e8c-11ed-861d-0242ac120002",
                Email = "admin@localhost.com",
                NormalizedEmail = "admin@localhost.com",
                Name = "Admin",
                LastName = "Admin",
                UserName = "AdminAdmin",
                NormalizedUserName = "AdminAdmin",
                PasswordHash = hasher.HashPassword(null, "Clave123"),
                EmailConfirmed = true,
            },
            new ApplicationUser
            {
                Id = "865ce880-1e8d-11ed-861d-0242ac120002",
                Email = "operator@localhost.com",
                NormalizedEmail = "operator@localhost.com",
                Name = "Operator",
                LastName = "Operator",
                UserName = "OperatorOperator",
                NormalizedUserName = "PaperoPapero",
                PasswordHash = hasher.HashPassword(null, "Clave456"),
                EmailConfirmed = true,
            });
        }
    }
}