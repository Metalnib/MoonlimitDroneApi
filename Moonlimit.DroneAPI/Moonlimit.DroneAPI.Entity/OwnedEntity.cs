namespace Moonlimit.DroneAPI.Entity
{
    public class OwnedEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int CompanyAccountId { get; set; }
    }
}