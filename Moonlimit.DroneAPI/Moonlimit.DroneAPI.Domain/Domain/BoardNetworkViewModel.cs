namespace Moonlimit.DroneAPI.Domain
{
    public class BoardNetworkViewModel : OwnedDomain
    {
        public bool Enabled { get; set; }
        public string SsId { get; set; }
        public string Encryption { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string SubnetMask { get; set; }
    }
}