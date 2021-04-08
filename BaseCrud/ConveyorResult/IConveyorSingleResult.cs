using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorSingleResult<T> : IConveyorResult where T : class, IEntity
    {
        public T Data { get; set; }
    }
}