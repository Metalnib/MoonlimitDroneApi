using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Moonlimit.DroneAPI.Entity;
using Moonlimit.DroneAPI.Entity.UnitofWork;

namespace Moonlimit.DroneAPI.Domain.Service
{
    public class OwnedGenericService<Tv, Te> : IService<Tv, Te> where Tv : OwnedDomain
        where Te : OwnedEntity
    {

        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        protected IClaimValidator<Te> ClaimValidator;
        
        public OwnedGenericService(IUnitOfWork unitOfWork, IMapper mapper, IClaimValidator<Te> claimValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            ClaimValidator = claimValidator;
        }

        public virtual IEnumerable<Tv> GetAll()
        {
            var entities = _unitOfWork.GetRepository<Te>().GetQueryable(ClaimValidator.CanGet());
            return _mapper.Map<IEnumerable<Tv>>(source: entities);
        }
        public virtual Tv GetOne(int id)
        {
            var entity = _unitOfWork.GetRepository<Te>().GetOne(predicate: x => x.Id == id);
            return ClaimValidator.CanGet(entity) ? _mapper.Map<Tv>(source: entity) : null;
        }

        public virtual int Add(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            if (ClaimValidator.CanAdd(entity)) return -1;
            _unitOfWork.GetRepository<Te>().Insert(entity);
            _unitOfWork.Save();
            return entity.Id;
        }

        public virtual int Update(Tv view)
        {
            var entity = _mapper.Map<Te>(source: view);
            if (!ClaimValidator.CanUpdate(entity)) return -1;
            _unitOfWork.GetRepository<Te>().Update(view.Id, entity);
            return _unitOfWork.Save();
        }


        public virtual int Remove(int id)
        {
            Te entity = _unitOfWork.Context.Set<Te>().Find(id);
            if (!ClaimValidator.CanRemove(entity)) return -1;
            _unitOfWork.GetRepository<Te>().Delete(entity);
            return _unitOfWork.Save();
        }

        public virtual IEnumerable<Tv> Get(Expression<Func<Te, bool>> predicate)
        {
            var entities = _unitOfWork.GetRepository<Te>().Get(predicate: predicate);
            return _mapper.Map<IEnumerable<Tv>>(source: entities.Where(e=>ClaimValidator.CanGet(e)));
        }
    }
}