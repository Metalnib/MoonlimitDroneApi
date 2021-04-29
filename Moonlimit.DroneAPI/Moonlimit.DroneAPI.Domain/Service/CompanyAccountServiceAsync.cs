using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class CompanyAccountServiceAsync<Tv, Te> : GenericServiceAsync<Tv, Te>
                                        where Tv : CompanyAccountViewModel
                                        where Te : CompanyAccount
    {
        //DI must be implemented specific service as well beside GenericAsyncService constructor
        public CompanyAccountServiceAsync(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        public async Task<Tv> GetAccountWithUsers(Int64 id)
        {
            var a = await _unitOfWork.Context.Set<CompanyAccount>().Where(a => a.Id == id).Include(a => a.Users).FirstOrDefaultAsync();
            return _mapper.Map<Tv>(a);
        }
    }

}
