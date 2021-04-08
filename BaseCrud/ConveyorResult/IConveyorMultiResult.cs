using System.Collections.Generic;
using BaseCrud.Domain;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorMultiResult<T> : IConveyorResult where T : class, IEntity
    {
        public IEnumerable<T> Data { get; set; }
    }
}