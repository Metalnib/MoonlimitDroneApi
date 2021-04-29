using System;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Moonlimit.DroneAPI.Entity.DroneCom
{
    [Table("status_reports", Schema = "DroneCom")]
    public class StatusReport : BaseEntity
    {
        public Int64 DroneId { get; set; }
        public DateTime LastReportTime { get; set; }
        public bool Armed { get; set; }
        public bool Disabled { get; set; }
        public bool Failsafe { get; set; }
        public float Battery { get; set; }
        public int DroneStateType { get; set; }
        public int DroneActionType { get; set; }
        public bool DroneActionComplete { get; set; }
        public int MissionStateType { get; set; }
        public int GpsQuality { get; set; }
        [Column(TypeName="geography")]
        public Point Location { get; set; }
    }
}