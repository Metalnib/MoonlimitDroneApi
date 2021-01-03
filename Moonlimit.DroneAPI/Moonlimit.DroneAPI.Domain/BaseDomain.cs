using AutoMapper.Configuration.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Domain
{
    public class BaseDomain
    {
        public int Id { get; set; }
        [MapTo("xmin")]
        public uint RowVersion { get; set; }

        //-----------------
        public string TestText { get; set; }  //string item for T4 generated tests
    }
}
