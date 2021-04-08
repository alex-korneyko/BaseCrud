using BaseCrud.Services;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorResultBuilder
    {
        public void SetConveyorResultCode(ConveyorResultCode conveyorResultCode);
        public void SetAuthorizationMessage(string message);
        public void SetValidationMessage(string message);
        public void SetServiceMessage(string message);
        public void SetDaoMessage(string message);
        public IConveyorResult GetConveyorResult();
    }
}