namespace Moonlimit.DroneAPI.Domain
{
    public class OwnedDomain : BaseDomain
    {
        public IdType UserId { get; set; }
        public IdType CompanyAccountId { get; set; }
    }
}