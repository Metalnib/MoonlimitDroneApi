using System;

namespace Moonlimit.DroneAPI.Entity
{
    public class OwnedEntity : BaseEntity
    {
        public Int64 UserId { get; set; }
        public Int64 CompanyAccountId { get; set; }
    }
}