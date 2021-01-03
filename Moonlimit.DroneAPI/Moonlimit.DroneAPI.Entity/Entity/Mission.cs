using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace Moonlimit.DroneAPI.Entity
{
    public class Mission : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }
        public int UserId { get; set; }
        public int MissionAreaId { get; set; }
        public int TypeCode { get; set; }
        public float TargetAltitude { get; set; }
        public GeoArea MissionArea { get; set; }
        public ICollection<GeoArea> InterestAreas { get; set; }
        public ICollection<GeoArea> AvoidAreas { get; set; }
        public List<Point> DroneBases { get; set; }
        public int PatrolConfigId { get; set; }
        public PatrolConfig PatrolConfig { get; set; }
    }
}