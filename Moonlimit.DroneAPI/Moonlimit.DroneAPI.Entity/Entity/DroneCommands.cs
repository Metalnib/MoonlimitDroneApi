using System;

namespace Moonlimit.DroneAPI.Entity
{
    public class DroneCommands : BaseEntity
    {
        public int DroneId { get; set; }
        public DateTime Time { get; set; }
        public int Action { get; set; }
    }
}