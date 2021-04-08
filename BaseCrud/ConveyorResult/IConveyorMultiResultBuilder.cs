using System.Collections.Generic;
using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorMultiResultBuilder<T> : IConveyorResultBuilder where T : class, IEntity
    {
        public void SetData(IEnumerable<T> data);
    }
}