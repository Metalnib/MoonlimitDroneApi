namespace Moonlimit.DroneAPI.Domain.Service
{
    using AutoMapper;
    using Moonlimit.DroneAPI.Entity;
    using Moonlimit.DroneAPI.Entity.UnitofWork;
    using Moonlimit.DroneAPI.Entity.DroneCom;
    using System.Collections.Generic;

    /// <summary>
    /// A Mission service
    /// </summary>
    public class MissionServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
        where Tv : MissionViewModel
        where Te : Mission
    {
        
        public MissionServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }
        
        public IEnumerable<Tv> GetMissionsByUserIdAsync(int userId)
        {
            return _mapper.Map<IEnumerable<Tv>>(_unitOfWork.GetRepository<Mission>().Get(m => m.UserId == userId));
        }
    }
}