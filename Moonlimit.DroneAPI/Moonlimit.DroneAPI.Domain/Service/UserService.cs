using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class UserService<Tv, Te> : GenericService<Tv, Te>
                                                where Tv : UserViewModel
                                                where Te : User
    {
        //DI must be implemented in specific service as well beside GenericService constructor
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (_unitOfWork == null)
                _unitOfWork = unitOfWork;
            if (_mapper == null)
                _mapper = mapper;
        }

        
        public IEnumerable<UserViewModel> GetUsersByName(string firstName, string lastName)
        {
            return null; //Not working yet 
            var parameters = new[] {
                new NpgsqlParameter("@FirstName", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = firstName },
                new NpgsqlParameter("@LastName", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = lastName }
                };
            string sql = "EXEC [dbo].[prGetUserByFirstandLastName] @FirstName, @LastName";

            var users = _unitOfWork.GetRepository<User>().READbyStoredProcedure(sql, parameters);
            return _mapper.Map<IEnumerable<UserViewModel>>(source: users);
        }

        
        public int UpdateEmailByUsername(string username, string email)
        {
            return 0; //Not working yet
            var parameters = new[] {
                new NpgsqlParameter("@UserName", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = username },
                new NpgsqlParameter("@Email", SqlDbType.VarChar) { Direction = ParameterDirection.Input, Value = email }
                };
            string sql = "EXEC [dbo].[prUpdateEmailByUsername] @UserName, @Email";

            int records = _unitOfWork.GetRepository<User>().CUDbyStoredProcedure(sql, parameters);
            return records;
        }


    }

}
