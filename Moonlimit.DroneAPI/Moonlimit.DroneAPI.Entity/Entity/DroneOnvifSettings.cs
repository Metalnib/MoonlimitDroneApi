using System.ComponentModel.DataAnnotations;

namespace Moonlimit.DroneAPI.Entity
{
    public class DroneOnvifSettings : BaseEntity
    {
        public bool Enabled { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public int ServicePort { get; set; }
    }
}