namespace Moonlimit.DroneAPI.Domain.Service
{
    using AutoMapper;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.UnitofWork;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    
    /// <summary>
    ///
    /// A DroneNetworkSettings service
    ///       
    /// </summary>
    /// <summary>
    /// A DroneNetworkSettings service
    /// </summary>
    public class DroneNetworkSettingsServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
        where Tv : DroneNetworkSettingsViewModel
        where Te : DroneNetworkSettings
    {
        
        public DroneNetworkSettingsServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        
    }
}