using BaseCrud.Domain;

namespace BaseCrud.DAO
{
    public interface IDao<TEntity> : ICrud<TEntity> 
        where TEntity : class, IEntity 
    {
        
    }
}