namespace Moonlimit.DroneAPI.Domain
{
    public class MissionViewModel : BaseDomain
    {
        public string Name { get; set; } 
        public int UserId { get; set; } 
        public int MissionAreaId { get; set; } 
        public int TypeCode { get; set; } 
        public float TargetAltitude { get; set; } 
        public virtual GeoAreaViewModel MissionArea { get; set; } 
        public virtual System.Collections.Generic.ICollection<GeoAreaViewModel> InterestAreas { get; set; } 
        public virtual System.Collections.Generic.ICollection<GeoAreaViewModel> AvoidAreas { get; set; } 
        public System.Collections.Generic.List<NetTopologySuite.Geometries.Point> DroneBases { get; set; } 
        public int PatrolConfigId { get; set; } 
        public virtual PatrolConfigViewModel PatrolConfig { get; set; } 
    } 
}