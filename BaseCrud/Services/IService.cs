using BaseCrud.Domain;

namespace BaseCrud.Services
{
    public interface IService<T> : ICrud<T> where T : class, IEntity
    {
    }
}