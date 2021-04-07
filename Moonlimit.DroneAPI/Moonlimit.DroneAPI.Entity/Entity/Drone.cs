using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Entity
{
    public class Drone : BaseEntity
    {
        [StringLength(128)]
        public string Name { get; set; }
        [StringLength(128)]
        public string TagNumber { get; set; }
        [StringLength(255)]
        public string Owner { get; set; }
        [StringLength(128)]
        public string PlatformCode { get; set; }
        [StringLength(128)]
        public string OnboardCode { get; set; }
        public int UserId { get; set; }
        public int AssignedMissionId { get; set; }
        public Mission AssignedMission { get; set; }
        [Required]
        [StringLength(255)]
        public string Token { get; set; }
        public int OnvifSettingsId { get; set; }
        public DroneOnvifSettings OnvifSettings { get; set; }
        public int BoardNetworkId { get; set; }
        public BoardNetwork BoardNetwork { get; set; }
        public DateTime LastOnline { get; set; }
        public DroneStatusCode StatusCode { get; set; }
        public DroneFlightStatusCode FlightStatusCode { get; set; }
        public ICollection<DroneNetworkSettings> Networks { get; set; }
    }

    public enum DroneStatusCode
    {
        Unset, Maintenance, Initializing, Ok, Problem
    }

    public enum DroneFlightStatusCode
    {
        Unset, Landed, Flying
    }
}