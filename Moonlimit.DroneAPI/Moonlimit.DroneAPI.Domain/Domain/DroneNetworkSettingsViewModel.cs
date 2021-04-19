namespace Moonlimit.DroneAPI.Domain
{
    public class DroneNetworkSettingsViewModel : OwnedDomain
    {
        public int UserId { get; set; } 
        public string NetworkInterface { get; set; } 
        public string SsId { get; set; } 
        public bool UseDhcp { get; set; } 
        public string Encryption { get; set; } 
        public string Password { get; set; } 
        public string IpAddress { get; set; } 
        public string SubnetMask { get; set; } 
        public string Router { get; set; } 
        public string DnsHostname { get; set; } 
        public short Order { get; set; } 
        public virtual System.Collections.Generic.ICollection<DroneViewModel> Drones { get; set; } 
    }
}