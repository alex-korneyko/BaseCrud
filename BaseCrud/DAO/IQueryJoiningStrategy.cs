using System.Linq;
using BaseCrud.Domain;

namespace BaseCrud.DAO
{
    public interface IQueryJoiningStrategy<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAllJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> GetRangeJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> GetByIdJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> AddJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> AddRangeJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> UpdateJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> UpdateRangeJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> DeleteJoiningStrategy(IQueryable<TEntity> values);
        IQueryable<TEntity> DeleteRangeJoiningStrategy(IQueryable<TEntity> values);
    }
}