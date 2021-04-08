using BaseCrud.Services;

namespace BaseCrud.ConveyorResult
{
    public abstract class ConveyorResultBuilder : IConveyorResultBuilder
    {
        protected IConveyorResult ConveyorResult { get; set; }

        public void SetConveyorResultCode(ConveyorResultCode conveyorResultCode)
        {
            ConveyorResult.ConveyorResultCode = conveyorResultCode;
        }

        public void SetAuthorizationMessage(string message)
        {
            ConveyorResult.AuthorizationMessage = message;
        }

        public void SetValidationMessage(string message)
        {
            ConveyorResult.ValidationMessage = message;
        }

        public void SetServiceMessage(string message)
        {
            ConveyorResult.ServiceMessage = message;
        }

        public void SetDaoMessage(string message)
        {
            ConveyorResult.DaoMessage = message;
        }

        public IConveyorResult GetConveyorResult()
        {
            return ConveyorResult;
        }
    }
}