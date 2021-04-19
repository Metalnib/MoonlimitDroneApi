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
    public class DroneNetworkSettingsService<Tv, Te> : OwnedGenericService<Tv, Te>
        where Tv : DroneNetworkSettingsViewModel
        where Te : DroneNetworkSettings
    {
        
        public DroneNetworkSettingsService(IUnitOfWork unitOfWork, IMapper mapper, IClaimValidator<Te> validator):base(unitOfWork,mapper,validator)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        
    }
}