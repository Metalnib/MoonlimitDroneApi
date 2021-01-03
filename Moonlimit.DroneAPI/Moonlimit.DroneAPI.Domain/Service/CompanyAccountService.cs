using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class CompanyAccountService<Tv, Te> : GenericService<Tv, Te>
                                        where Tv : CompanyAccountViewModel
                                        where Te : CompanyAccount
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public CompanyAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        public Tv GetAccountWithUsers(int id)
        {
            var a = _unitOfWork.Context.Set<CompanyAccount>().Where(a => a.Id == id).Include(a => a.Users).FirstOrDefault();
            return _mapper.Map<Tv>(a);
        }
    }

}
