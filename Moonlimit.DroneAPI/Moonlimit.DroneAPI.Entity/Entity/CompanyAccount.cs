using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Moonlimit.DroneAPI.Entity
{
    /// <summary>
    /// A account with users
    /// </summary>
    public class CompanyAccount : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }

        public ICollection<User> Users { get; set; }

    }




}
