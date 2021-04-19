using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moonlimit.DroneAPI.Entity;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class BasicClaimValidator<Te> : IClaimValidator<Te> where Te : OwnedEntity
    {
        private static readonly List<string> FullAccessRoles = new() {"Administrator","Owner","Manager"};
        private readonly IClaimsData _claims;
        
        public BasicClaimValidator(IClaimsData claims)
        {
            _claims = claims;
        }
        
        public Expression<Func<Te, bool>> CanAdd() 
            => obj=>obj.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
               _claims.Roles.Contains("Administrator");
        public bool CanAdd(Te entity)
            => entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
               _claims.Roles.Contains("Administrator");
        
        public Expression<Func<Te, bool>> CanUpdate()
            => entity =>entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
                        _claims.Roles.Contains("Administrator");
        public bool CanUpdate(Te entity)
            => entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
              _claims.Roles.Contains("Administrator");
        
        public Expression<Func<Te, bool>> CanRemove()
            => entity =>entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
                        _claims.Roles.Contains("Administrator");
        public bool CanRemove(Te entity)
            => entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
                _claims.Roles.Contains("Administrator");
        public bool CanGet(Te entity)
            => entity.UserId == _claims.UserId ||
               entity.CompanyAccountId == _claims.AccountId && _claims.Roles.Intersect(FullAccessRoles).Any() ||
               _claims.Roles.Contains("Administrator");
        
        public Expression<Func<Te, bool>> CanGet()
            => entity => entity.UserId == _claims.UserId ||
                     entity.CompanyAccountId == _claims.AccountId &&
                     _claims.Roles.Intersect(FullAccessRoles).Any() ||
                     _claims.Roles.Contains("Administrator");
    }

    public interface IClaimValidator<Te> where Te : OwnedEntity
    {
        bool CanGet(Te entity);
        bool CanAdd(Te obj);
        bool CanRemove(Te entity);
        bool CanUpdate(Te entity);
        Expression<Func<Te, bool>> CanAdd();
        Expression<Func<Te, bool>> CanUpdate();
        Expression<Func<Te, bool>> CanRemove();
        Expression<Func<Te, bool>> CanGet();
    }
}