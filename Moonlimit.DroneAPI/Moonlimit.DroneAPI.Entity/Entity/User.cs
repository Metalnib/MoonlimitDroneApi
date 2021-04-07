using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Moonlimit.DroneAPI.Entity
{
    /// <summary>
    /// A user attached to an account
    /// </summary>
    public class User : BaseEntity
    {
        [Required]
        [StringLength(64)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(64)]
        public string LastName { get; set; }
        [Required]
        [StringLength(32)]
        public string UserName { get; set; }
        [Required]
        [StringLength(128)]
        public string Email { get; set; }
        public bool IsAdminRole { get; set; }
        [StringLength(255)]
        public string Roles { get; set; }   //TODO: Consider this to be array of strings 
        public bool IsActive { get; set; }
        [StringLength(128)]
        public string Password { get; set; }   //stored encrypted
        [NotMapped]
        public string DecryptedPassword
        {
            get { return Decrypt(Password); }
            set { Password = Encrypt(value); }
        }
        public int CompanyAccountId { get; set; }
        [StringLength(128)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public CompanyAccount CompanyAccount { get; set; }

        private string Decrypt(string cipherText)
        {
            return EntityHelper.Decrypt(cipherText);
        }
        private string Encrypt(string clearText)
        {
            return EntityHelper.Encrypt(clearText);
        }
    }
}
