using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "d735fa86-1e8c-11ed-861d-0242ac120002",
                    RoleId = "b3c3c19c-1e95-11ed-861d-0242ac120002"
                },
                new IdentityUserRole<string>
                {
                    UserId = "865ce880-1e8d-11ed-861d-0242ac120002",
                    RoleId = "cc292a9c-1e95-11ed-861d-0242ac120002"
                });
        }
    }
}
