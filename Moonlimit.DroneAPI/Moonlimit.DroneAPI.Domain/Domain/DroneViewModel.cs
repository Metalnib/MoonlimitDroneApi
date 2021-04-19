namespace Moonlimit.DroneAPI.Domain
{
    using Moonlimit.DroneAPI.Entity;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class DroneViewModel : OwnedDomain
    {
        public string Name { get; set; } 
        public string TagNumber { get; set; } 
        public string Owner { get; set; } 
        public string PlatformCode { get; set; } 
        public string OnboardCode { get; set; }
        public int? AssignedMissionId { get; set; } 
        public virtual MissionViewModel AssignledMission { get; set; } 
        public string Token { get; set; } 
        public int? OnvifSettingsId { get; set; } 
        public virtual DroneOnvifSettingsViewModel OnvifSettings { get; set; } 
        public System.DateTime LastOnline { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual DroneStatusCode StatusCode { get; set; } 
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual DroneFlightStatusCode FlightStatusCode { get; set; } 
        public virtual System.Collections.Generic.ICollection<DroneNetworkSettingsViewModel> Networks { get; set; } 
    }
}