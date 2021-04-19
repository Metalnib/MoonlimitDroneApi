namespace Moonlimit.DroneAPI.Domain
{
    public class OwnedDomain : BaseDomain
    {
        public int UserId { get; set; }
        public int CompanyAccountId { get; set; }
    }
}