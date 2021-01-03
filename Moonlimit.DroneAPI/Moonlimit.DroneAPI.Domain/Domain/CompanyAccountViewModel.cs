using AutoMapper;
using System;
using System.Collections.Generic;

namespace Moonlimit.DroneAPI.Domain
{
    /// <summary>
    /// A account with users
    /// </summary>
    public class CompanyAccountViewModel : BaseDomain
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
        public DateTime SetActive { get; set; }

        public ICollection<UserViewModel> Users { get; set; }
    }

}


