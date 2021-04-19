using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moonlimit.DroneAPI.Entity
{
    public class DroneNetworkSettings : OwnedEntity
    {
        [StringLength(128)]
        public string SsId { get; set; }
        public bool UseDhcp { get; set; }
        [StringLength(128)]
        public string Encryption { get; set; }
        [StringLength(128)]
        public string Password { get; set; }
        [StringLength(45)]
        public string IpAddress { get; set; }
        [StringLength(16)]
        public string SubnetMask { get; set; }
        [StringLength(16)]
        public string Router { get; set; }
        [StringLength(255)]
        public string DnsHostname { get; set; }
        public short Order { get; set; }
        public ICollection<Drone> Drones { get; set; }
    }
}