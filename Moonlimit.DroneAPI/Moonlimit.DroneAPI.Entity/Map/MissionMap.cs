using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moonlimit.DroneAPI.Entity.Map
{
    public class MissionMap : BaseEntityMap<Mission>
    {
        protected override void InternalMap(EntityTypeBuilder<Mission> builder)
        {
            builder.HasIndex(e => e.UserId).IncludeProperties(e => e.Name);
        }
    }
}