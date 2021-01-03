using System;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Domain.Service
{
    using AutoMapper;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.UnitofWork;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    
    /// <summary>
    /// A Drone service
    /// </summary>
    public class DroneServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
        where Tv : DroneViewModel
        where Te : Drone
    {
        
        public DroneServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        
        public override async Task<int> Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            if(string.IsNullOrWhiteSpace(entity.Token)) entity.Token = Guid.NewGuid().ToString();
            entity.OnvifSettings ??= new DroneOnvifSettings()
                {Enabled = false, Password = "unknown", UserName = "admin"};
            
            await _unitOfWork.GetRepositoryAsync<Te>().Insert(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }
    }
}