using System.ComponentModel.DataAnnotations;

namespace Moonlimit.DroneAPI.Entity
{
    public class DroneOnvifSettings : BaseEntity
    {
        public bool Enabled { get; set; }
        [StringLength(64)]
        public string UserName { get; set; }
        [StringLength(128)]
        public string Password { get; set; }
        public int ServicePort { get; set; }
        [StringLength(45)]
        public string ListeningAddress { get; set; }
    }
}