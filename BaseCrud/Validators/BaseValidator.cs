using System.Collections.Generic;
using BaseCrud.ConveyorResult;
using BaseCrud.Domain;
using BaseCrud.Services;

namespace BaseCrud.Validators
{
    public class BaseValidator<T> : IValidator<T> where T : class, IEntity
    {
        private readonly IService<T> _service;

        public BaseValidator(IService<T> service)
        {
            _service = service;
        }

        public virtual IConveyorMultiResultBuilder<T> GetAll()
        {
            var conveyorMultiResultBuilder = _service.GetAll();
            
            conveyorMultiResultBuilder.SetValidationMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> GetRange(IEnumerable<long> idRange)
        {
            var conveyorMultiResultBuilder = _service.GetRange(idRange);

            conveyorMultiResultBuilder.SetValidationMessage("Ok");
            
            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> GetById(long id)
        {
            var conveyorSingleResultBuilder = _service.GetById(id);
            
            conveyorSingleResultBuilder.SetValidationMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Add(T entity)
        {
            var conveyorSingleResultBuilder = _service.Add(entity);
            
            conveyorSingleResultBuilder.SetValidationMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> AddRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _service.AddRange(entities);
            
            conveyorMultiResultBuilder.SetValidationMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Update(T entity)
        {
            var conveyorSingleResultBuilder = _service.Update(entity);
            
            conveyorSingleResultBuilder.SetValidationMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> UpdateRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _service.UpdateRange(entities);
            
            conveyorMultiResultBuilder.SetValidationMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Delete(T entity)
        {
            var conveyorSingleResultBuilder = _service.Delete(entity);
            
            conveyorSingleResultBuilder.SetValidationMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> DeleteRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _service.DeleteRange(entities);
            
            conveyorMultiResultBuilder.SetValidationMessage("Ok");

            return conveyorMultiResultBuilder;
        }
    }
}