namespace Moonlimit.DroneAPI.Domain.Service
{
    using System;
    using IdGen;
    using AutoMapper;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.UnitofWork;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    
    /// <summary>
    ///
    /// A Drone service
    ///       
    /// </summary>
    public class DroneService<Tv, Te> : OwnedGenericService<Tv, Te>
        where Tv : DroneViewModel
        where Te : Drone
    {
        
        public DroneService(IUnitOfWork unitOfWork, IMapper mapper, IClaimValidator<Te> validator, IdGenerator generator):base(unitOfWork,mapper,validator, generator)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        
        public override Int64 Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            if(string.IsNullOrWhiteSpace(entity.Token)) entity.Token = Guid.NewGuid().ToString();
            //entity.OnvifSettings ??= new DroneOnvifSettings {Enabled = false, Password = "unknown", UserName = "admin"};
            _unitOfWork.GetRepository<Te>().Insert(entity);
            _unitOfWork.Save();
            return entity.Id;
        }
    }
}