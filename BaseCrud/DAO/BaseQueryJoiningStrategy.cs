using System.Linq;
using BaseCrud.Domain;

namespace BaseCrud.DAO
{
    public class BaseQueryJoiningStrategy<TEntity> : IQueryJoiningStrategy<TEntity> where TEntity : class, IEntity
    {
        public virtual IQueryable<TEntity> GetAllJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> GetRangeJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> GetByIdJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> AddJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> AddRangeJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> UpdateJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> UpdateRangeJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> DeleteJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }

        public virtual IQueryable<TEntity> DeleteRangeJoiningStrategy(IQueryable<TEntity> values)
        {
            return values;
        }
    }
}