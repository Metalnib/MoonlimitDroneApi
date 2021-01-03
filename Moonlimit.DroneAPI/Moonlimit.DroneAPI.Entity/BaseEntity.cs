using AutoMapper.Configuration.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Entity
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        //[ConcurrencyCheck]
        //[Timestamp]
        [MapTo("RowVersion")]
        public uint xmin { get; set; }

        //-----------------
        [StringLength(50)]
        public string TestText { get; set; }  //string item for T4 generated tests

    }
}
