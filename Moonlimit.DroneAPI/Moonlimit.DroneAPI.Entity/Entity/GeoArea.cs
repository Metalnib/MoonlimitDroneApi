using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Moonlimit.DroneAPI.Entity
{
    public class GeoArea : BaseEntity
    {
        public AreaKind Kind { get; set; }
        public ICollection<GeoPoint> Points{ get; set; }
    }

    public class GeoPoint : BaseEntity
    {
        [Column(TypeName="geography")]
        public Point Coordinates { get; set; }
    }

    public enum AreaKind { Unknoun, Avoid, Interest}
}