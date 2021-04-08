using System.Collections.Generic;
using BaseCrud.ConveyorResult;
using BaseCrud.DAO;
using BaseCrud.Domain;

namespace BaseCrud.Services
{
    public class BaseService<T> : IService<T> where T : class, IEntity
    {
        private readonly IDao<T> _dao;

        public BaseService(IDao<T> dao)
        {
            _dao = dao;
        }

        public virtual IConveyorMultiResultBuilder<T> GetAll()
        {
            var conveyorMultiResultBuilder = _dao.GetAll();
            
            conveyorMultiResultBuilder.SetServiceMessage("Ok");
            
            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> GetRange(IEnumerable<long> idRange)
        {
            var conveyorMultiResultBuilder = _dao.GetRange(idRange);
            
            conveyorMultiResultBuilder.SetServiceMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> GetById(long id)
        {
            var conveyorSingleResultBuilder = _dao.GetById(id);
            
            conveyorSingleResultBuilder.SetServiceMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Add(T entity)
        {
            var conveyorSingleResultBuilder = _dao.Add(entity);
            
            conveyorSingleResultBuilder.SetServiceMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> AddRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _dao.AddRange(entities);
            
            conveyorMultiResultBuilder.SetServiceMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Update(T entity)
        {
            var conveyorSingleResultBuilder = _dao.Update(entity);
            
            conveyorSingleResultBuilder.SetServiceMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> UpdateRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _dao.UpdateRange(entities);
            
            conveyorMultiResultBuilder.SetServiceMessage("Ok");

            return conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<T> Delete(T entity)
        {
            var conveyorSingleResultBuilder = _dao.Delete(entity);
            
            conveyorSingleResultBuilder.SetServiceMessage("Ok");

            return conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<T> DeleteRange(IEnumerable<T> entities)
        {
            var conveyorMultiResultBuilder = _dao.DeleteRange(entities);
            
            conveyorMultiResultBuilder.SetServiceMessage("Ok");

            return conveyorMultiResultBuilder;
        }
    }
}