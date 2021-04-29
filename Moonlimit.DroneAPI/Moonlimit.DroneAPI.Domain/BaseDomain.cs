using AutoMapper.Configuration.Conventions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moonlimit.DroneAPI.Domain
{
    public class BaseDomain
    {
        public Int64 Id { get; set; }
        private string _lid;
        public string LId
        {
            get
            {
                if (string.IsNullOrEmpty(_lid))
                    _lid = Base32Convert.ToString(Id);
                return _lid;
            }
            set
            {
                Id = Base32Convert.ToInt64(value);
                _lid = value;
            }
        }

        [MapTo("xmin")]
        public uint RowVersion { get; set; }

        //-----------------
        public string TestText { get; set; }  //string item for T4 generated tests
    }
}
