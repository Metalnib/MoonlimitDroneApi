using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Entity
{
    public class BoardNetwork : OwnedEntity
    {
        public bool Enabled { get; set; }
        [StringLength(128)]
        public string SsId { get; set; }
        [StringLength(128)]
        public string Encryption { get; set; }
        [StringLength(128)]
        public string Password { get; set; }
        [StringLength(45)]
        public string IpAddress { get; set; }
        [StringLength(16)]
        public string SubnetMask { get; set; }
    }
}
