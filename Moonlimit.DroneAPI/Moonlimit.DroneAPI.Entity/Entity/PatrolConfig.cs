namespace Moonlimit.DroneAPI.Entity
{
    public class PatrolConfig : BaseEntity
    {
        public float FollowDistance { get; set; }
        public float RelativeAltitude { get; set; }
        public float PersonScoreThreshold { get; set; }
        public float VehicleScoreThreshold { get; set; }
        public float TargetLostTimeouts { get; set; }
    }
}