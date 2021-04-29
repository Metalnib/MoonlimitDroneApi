using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Moonlimit.DroneAPI.Entity.DroneCom
{
    [Table("object_detections", Schema = "DroneCom")]
    public class ObjectDetection : BaseEntity
    {
        public Int64 DroneId { get; set; }
        public Int64 MissionId { get; set; }
        [StringLength(255)]
        public string TagNumber { get; set; }
        [StringLength(255)]
        public string Token { get; set; }
        [Column(TypeName="geography")]
        public Point Location { get; set; }
        [StringLength(255)]
        public string ObjectType { get; set; }
        public int ObjectId { get; set; }
        public byte[] Image { get; set; }
    }
}