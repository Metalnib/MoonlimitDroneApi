using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class UserServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                                where Tv : UserViewModel
                                                where Te : User
    {
        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public UserServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

    }

}
