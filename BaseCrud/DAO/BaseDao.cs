using System;
using System.Collections.Generic;
using System.Linq;
using BaseCrud.ConveyorResult;
using BaseCrud.Domain;
using BaseCrud.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCrud.DAO
{
    public class BaseDao<TEntity> : IDao<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSetValues;
        private readonly DbContext _context;
        private readonly IQueryJoiningStrategy<TEntity> _joiningStrategy;
        private readonly IConveyorSingleResultBuilder<TEntity> _conveyorSingleResultBuilder;
        private readonly IConveyorMultiResultBuilder<TEntity> _conveyorMultiResultBuilder;

        public BaseDao(IServiceProvider serviceProvider)
        {
            _context = (DbContext) serviceProvider.GetService(ServiceConfiguration.DbContextImplementation);
            _joiningStrategy = serviceProvider.GetService<IQueryJoiningStrategy<TEntity>>();
            _conveyorSingleResultBuilder = serviceProvider.GetService<IConveyorSingleResultBuilder<TEntity>>();
            _conveyorMultiResultBuilder = serviceProvider.GetService<IConveyorMultiResultBuilder<TEntity>>();
            _dbSetValues = ServiceUtils.GetDbSet<TEntity>(_context);
        }

        public virtual IConveyorMultiResultBuilder<TEntity> GetAll()
        {
            var entities = _joiningStrategy.GetAllJoiningStrategy(_dbSetValues).ToList();

            _conveyorMultiResultBuilder.SetData(entities);
            _conveyorMultiResultBuilder.SetDaoMessage("Ok");
            _conveyorMultiResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorMultiResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<TEntity> GetRange(IEnumerable<long> idRange)
        {
            var entities = idRange.Select(id => _joiningStrategy.GetRangeJoiningStrategy(_dbSetValues)
                    .FirstOrDefault(entity => entity.Id == id))
                .Where(firstEntity => firstEntity != null)
                .ToList();

            _conveyorMultiResultBuilder.SetData(entities);
            _conveyorMultiResultBuilder.SetDaoMessage("Ok");
            _conveyorMultiResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<TEntity> GetById(long id)
        {
            var firstOrDefault = _joiningStrategy.GetByIdJoiningStrategy(_dbSetValues)
                .FirstOrDefault(entity => entity.Id == id);

            _conveyorSingleResultBuilder.SetData(firstOrDefault);
            _conveyorSingleResultBuilder.SetDaoMessage("Ok");
            _conveyorSingleResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorSingleResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<TEntity> Add(TEntity entity)
        {
            _dbSetValues.Add(entity);
            _context.SaveChanges();

            var firstOrDefault = _joiningStrategy.AddJoiningStrategy(_dbSetValues)
                .FirstOrDefault(ent => ent.Id == entity.Id);

            _conveyorSingleResultBuilder.SetData(firstOrDefault);
            _conveyorSingleResultBuilder.SetDaoMessage("Ok");
            _conveyorSingleResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            var entitiesArray = entities as TEntity[] ?? entities.ToArray();

            _dbSetValues.AddRange(entitiesArray);
            _context.SaveChanges();

            var entitiesListFromDb = entitiesArray.Select(ent => _joiningStrategy.AddRangeJoiningStrategy(_dbSetValues)
                    .FirstOrDefault(entity => entity.Id == ent.Id))
                .Where(firstEntity => firstEntity != null)
                .ToList();

            _conveyorMultiResultBuilder.SetData(entitiesListFromDb);
            _conveyorMultiResultBuilder.SetDaoMessage("Ok");
            _conveyorMultiResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<TEntity> Update(TEntity entity)
        {
            _dbSetValues.Update(entity);
            _context.SaveChanges();

            var firstOrDefault = _joiningStrategy.UpdateJoiningStrategy(_dbSetValues)
                .FirstOrDefault(ent => ent.Id == entity.Id);

            _conveyorSingleResultBuilder.SetData(firstOrDefault);
            _conveyorSingleResultBuilder.SetDaoMessage("Ok");
            _conveyorSingleResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            var entitiesArray = entities as TEntity[] ?? entities.ToArray();

            _dbSetValues.UpdateRange(entitiesArray);
            _context.SaveChanges();

            var entitiesListFromDb = entitiesArray.Select(ent => _joiningStrategy.UpdateRangeJoiningStrategy(_dbSetValues)
                    .FirstOrDefault(entity => entity.Id == ent.Id))
                .Where(firstEntity => firstEntity != null)
                .ToList();

            _conveyorMultiResultBuilder.SetData(entitiesListFromDb);
            _conveyorMultiResultBuilder.SetDaoMessage("Ok");
            _conveyorMultiResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorMultiResultBuilder;
        }

        public virtual IConveyorSingleResultBuilder<TEntity> Delete(TEntity entity)
        {
            _dbSetValues.Remove(entity);
            _context.SaveChanges();

            var firstOrDefault = _joiningStrategy.DeleteJoiningStrategy(_dbSetValues)
                .FirstOrDefault(ent => ent.Id == entity.Id);

            _conveyorSingleResultBuilder.SetData(firstOrDefault);
            _conveyorSingleResultBuilder.SetDaoMessage("Ok");
            _conveyorSingleResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorSingleResultBuilder;
        }

        public virtual IConveyorMultiResultBuilder<TEntity> DeleteRange(IEnumerable<TEntity> entities)
        {
            var entitiesArray = entities as TEntity[] ?? entities.ToArray();

            _dbSetValues.RemoveRange(entitiesArray);
            _context.SaveChanges();

            var entitiesListFromDb = entitiesArray.Select(ent => _joiningStrategy.DeleteRangeJoiningStrategy(_dbSetValues)
                    .FirstOrDefault(entity => entity.Id == ent.Id))
                .Where(firstEntity => firstEntity != null)
                .ToList();

            _conveyorMultiResultBuilder.SetData(entitiesListFromDb);
            _conveyorMultiResultBuilder.SetDaoMessage("Ok");
            _conveyorMultiResultBuilder.SetConveyorResultCode(ConveyorResultCode.Ok);

            return _conveyorMultiResultBuilder;
        }
    }
}