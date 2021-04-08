using System.Collections.Generic;
using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public class ConveyorMultiResultBuilder<T> : ConveyorResultBuilder, IConveyorMultiResultBuilder<T> where T : class, IEntity
    {
        public ConveyorMultiResultBuilder()
        {
            ConveyorResult = new BaseConveyorMultiResult<T>();
        }

        public void SetData(IEnumerable<T> data)
        {
            ((BaseConveyorMultiResult<T>) ConveyorResult).Data = data;
        }
    }
}