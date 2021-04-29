using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public interface IServiceAsync<Tv, Te>
    {
        Task<IEnumerable<Tv>> GetAll();
        Task<Int64> Add(Tv obj);
        Task<Int64> Update(Tv obj);
        Task<Int64> Remove(Int64 id);
        Task<Tv> GetOne(Int64 id);
        Task<IEnumerable<Tv>> Get(Expression<Func<Te, bool>> predicate);
    }

}
