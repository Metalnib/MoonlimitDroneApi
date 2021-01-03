using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moonlimit.DroneAPI.Entity.Map
{
    public class CompanyAccountMap : BaseEntityMap<CompanyAccount>
    {
        protected override void InternalMap(EntityTypeBuilder<CompanyAccount> builder)
        {
            builder.HasMany(a => a.Users).WithOne(u => u.CompanyAccount);
        }
    }
}
