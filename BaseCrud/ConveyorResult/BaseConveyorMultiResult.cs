using System.Collections.Generic;
using BaseCrud.Domain;
using BaseCrud.Services;

namespace BaseCrud.ConveyorResult
{
    public class BaseConveyorMultiResult<T> : IConveyorMultiResult<T> where T : class, IEntity
    {
        public string AuthorizationMessage { get; set; }
        public string ValidationMessage { get; set; }
        public string ServiceMessage { get; set; }
        public string DaoMessage { get; set; }
        public ConveyorResultCode ConveyorResultCode { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}