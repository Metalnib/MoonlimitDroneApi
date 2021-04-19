using System.Collections.Generic;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public interface IClaimsData
    {
        int UserId { get; }
        int AccountId { get; }
        IList<string> Roles { get; }
    }
}