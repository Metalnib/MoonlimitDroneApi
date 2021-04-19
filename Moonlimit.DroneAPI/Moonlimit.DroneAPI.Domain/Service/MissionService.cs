using System.Collections.Generic;
using System.Linq;

namespace Moonlimit.DroneAPI.Domain.Service
{
    using AutoMapper;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.UnitofWork;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    
    /// <summary>
    ///
    /// A Mission service
    ///       
    /// </summary>
    public class MissionService<Tv, Te> : OwnedGenericService<Tv, Te>
        where Tv : MissionViewModel
        where Te : Mission
    {
        
        public MissionService(IUnitOfWork unitOfWork, IMapper mapper, IClaimValidator<Te> validator):base(unitOfWork,mapper,validator)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        public IEnumerable<Mission> GetMissionsByUserId(int userId)
        {
            return _unitOfWork.GetRepository<Mission>().Get(m => m.UserId == userId);
        }
    }
}