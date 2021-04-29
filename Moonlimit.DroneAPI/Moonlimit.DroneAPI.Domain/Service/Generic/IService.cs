using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public interface IService<Tv, Te>
    {
        IEnumerable<Tv> GetAll();
        Int64 Add(Tv obj);
        Int64 Update(Tv obj);
        Int64 Remove(Int64 id);
        Tv GetOne(Int64 id);
        IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate);
    }
}
