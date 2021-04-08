using BaseCrud.Domain;

namespace BaseCrud.Validators
{
    public interface IValidator<T> : ICrud<T> where T : class, IEntity
    {
    }
}