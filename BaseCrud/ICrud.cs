using System.Collections.Generic;
using BaseCrud.ConveyorResult;
using BaseCrud.Domain;

namespace BaseCrud
{
    public interface ICrud<TEntity> 
        where TEntity : class, IEntity
    {
        IConveyorMultiResultBuilder<TEntity> GetAll();
        IConveyorMultiResultBuilder<TEntity> GetRange(IEnumerable<long> idRange);
        IConveyorSingleResultBuilder<TEntity> GetById(long id);
        IConveyorSingleResultBuilder<TEntity> Add(TEntity entity);
        IConveyorMultiResultBuilder<TEntity> AddRange(IEnumerable<TEntity> entities);
        IConveyorSingleResultBuilder<TEntity> Update(TEntity entity);
        IConveyorMultiResultBuilder<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        IConveyorSingleResultBuilder<TEntity> Delete(TEntity entity);
        IConveyorMultiResultBuilder<TEntity> DeleteRange(IEnumerable<TEntity> entities);
    }
}