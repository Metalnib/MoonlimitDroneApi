using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Moonlimit.DroneAPI.Entity
{
    public  class BaseEntityMap<TEntityType> : IEntityTypeMap
        where TEntityType : BaseEntity
    {
        public virtual void Map(ModelBuilder builder)
        {
            //concurrency
            builder.Entity<TEntityType>().UseXminAsConcurrencyToken();
            builder.Entity<TEntityType>()
                .Property(a => a.xmin).IsRowVersion();

            builder.Entity<TEntityType>().Property(e => e.CreatedAt).HasDefaultValueSql("now()");

            builder.Entity<TEntityType>().HasIndex(e => e.DeletedAt);
            
            InternalMap(builder.Entity<TEntityType>());
        }

        protected virtual void InternalMap(EntityTypeBuilder<TEntityType> builder)
        {
            //Do nothing
        }
    }
    
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }
}