using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public class ConveyorSingleResultBuilder<T> : ConveyorResultBuilder, IConveyorSingleResultBuilder<T> where T : class, IEntity
    {
        public ConveyorSingleResultBuilder()
        {
            ConveyorResult = new BaseConveyorSingleResult<T>();
        }
        
        public void SetData(T data)
        {
            ((BaseConveyorSingleResult<T>) ConveyorResult).Data = data;
        }
    }
}