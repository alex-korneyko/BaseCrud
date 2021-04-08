using BaseCrud.Services;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorResult
    {
        public string AuthorizationMessage { get; set; }
        public string ValidationMessage { get; set; }
        public string ServiceMessage { get; set; }
        public string DaoMessage { get; set; }
        public ConveyorResultCode ConveyorResultCode { get; set; }
    }
}