using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moonlimit.DroneAPI.Entity.Map
{
    public class DroneMap : BaseEntityMap<Drone>
    {
        protected override void InternalMap(EntityTypeBuilder<Drone> builder)
        {
            builder.HasIndex(e => e.Token);
            builder.HasIndex(e => e.Name).IncludeProperties(e => e.TagNumber);
            builder.HasIndex(e => e.UserId);
            builder.HasMany(d => d.Networks).WithMany(n => n.Drones);
        }
    }
}