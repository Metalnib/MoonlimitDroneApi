using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moonlimit.DroneAPI.Entity.Map
{
    public class UserMap : BaseEntityMap<User>
    {
        protected override void InternalMap(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.CompanyAccount);
            builder.HasIndex(u => u.UserName).IncludeProperties(u => u.Password);
        }
    }
}