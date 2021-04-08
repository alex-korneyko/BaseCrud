using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorSingleResultBuilder<in T> : IConveyorResultBuilder where T : class, IEntity
    {
        public void SetData(T data);
    }
}