using BaseCrud.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.ConveyorResult
{
    public interface IConveyorResultCreator<T> where T : class, IEntity
    {
        public IActionResult GetSingleResult(IConveyorSingleResultBuilder<T> singleResultBuilder);
        
        public IActionResult GetMultiResult(IConveyorMultiResultBuilder<T> multiResultBuilder);
    }
}