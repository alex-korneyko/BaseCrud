using BaseCrud.Domain;
using BaseCrud.Services;

namespace BaseCrud.ConveyorResult
{
    public class BaseConveyorSingleResult<T> : IConveyorSingleResult<T> where T : class, IEntity
    {
        public string AuthorizationMessage { get; set; }
        public string ValidationMessage { get; set; }
        public string ServiceMessage { get; set; }
        public string DaoMessage { get; set; }
        public ConveyorResultCode ConveyorResultCode { get; set; }
        public T Data { get; set; }
    }
}