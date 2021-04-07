using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moonlimit.DroneAPI.Entity.DroneCom;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite;

namespace Moonlimit.DroneAPI.Entity.Map
{
    public class DroneMap : BaseEntityMap<Drone>
    {
        protected override void InternalMap(EntityTypeBuilder<Drone> builder)
        {
            builder.HasOne(d => d.OnvifSettings);
            builder.HasIndex(e => e.Token);
            builder.HasIndex(e => e.Name).IncludeProperties(e => e.TagNumber);
            builder.HasIndex(e => e.UserId);
            builder.HasMany(d => d.Networks).WithMany(n => n.Drones);
        }
    }
}