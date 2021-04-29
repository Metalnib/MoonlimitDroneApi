using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Entity.DroneCom
{
    [Table("planned_routes", Schema = "DroneCom")]
    public class PlannedRoute : BaseEntity
    {
        public Int64 DroneId { get; set; }
        [Column(TypeName = "jsonb")]
        public string WaypointsJson { get; set; }
    }
}