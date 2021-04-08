using System.Collections.Generic;
using BaseCrud.ConveyorResult;
using BaseCrud.Domain;
using BaseCrud.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.Controllers
{
    public class BaseCrudController<T> : Controller, ICrudController<T> where T : class, IEntity
    {
        private readonly IValidator<T> _validator;
        private readonly IConveyorResultCreator<T> _conveyorResultCreator;

        public BaseCrudController(IValidator<T> validator, IConveyorResultCreator<T> conveyorResultCreator)
        {
            _validator = validator;
            _conveyorResultCreator = conveyorResultCreator;
        }

        [HttpPost("")]
        public virtual IActionResult GetAll()
        {
            var conveyorMultiResultBuilder = _validator.GetAll();

            return _conveyorResultCreator.GetMultiResult(conveyorMultiResultBuilder);
        }

        [HttpPost("getRange")]
        public virtual IActionResult GetRange(IEnumerable<long> idRange)
        {
            var conveyorMultiResultBuilder = _validator.GetRange(idRange);

            return _conveyorResultCreator.GetMultiResult(conveyorMultiResultBuilder);
        }

        [HttpPost("{id}")]
        public virtual IActionResult GetById(long id)
        {
            var conveyorSingleResultBuilder = _validator.GetById(id);

            return _conveyorResultCreator.GetSingleResult(conveyorSingleResultBuilder);
        }

        [HttpPost("add")]
        public virtual IActionResult Add(T entity)
        {
            var conveyorSingleResultBuilder = _validator.Add(entity);

            return _conveyorResultCreator.GetSingleResult(conveyorSingleResultBuilder);
        }

        [HttpPost("addRange")]
        public virtual IActionResult AddRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _validator.AddRange(entities);

            return _conveyorResultCreator.GetMultiResult(conveyorMultiResultBuilder);
        }

        [HttpPost("update")]
        public virtual IActionResult Update(T entity)
        {
            var conveyorSingleResultBuilder = _validator.Update(entity);

            return _conveyorResultCreator.GetSingleResult(conveyorSingleResultBuilder);
        }

        [HttpPost("updateRange")]
        public virtual IActionResult UpdateRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _validator.UpdateRange(entities);

            return _conveyorResultCreator.GetMultiResult(conveyorMultiResultBuilder);
        }

        [HttpPost("delete")]
        public virtual IActionResult Delete(T entity)
        {
            var conveyorSingleResultBuilder = _validator.Delete(entity);

            return _conveyorResultCreator.GetSingleResult(conveyorSingleResultBuilder);
        }

        [HttpPost("deleteRange")]
        public virtual IActionResult DeleteRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _validator.DeleteRange(entities);

            return _conveyorResultCreator.GetMultiResult(conveyorMultiResultBuilder);
        }
    }
}