using BaseCrud.DAO;
using BaseCrud.Domain;
using BaseCrud.Services;
using BaseCrud.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCrud.ServiceInjections
{
    public class ConveyorConfiguration<T> where T : class, IEntity
    {
        private readonly IServiceCollection _serviceCollection;

        internal readonly ConveyorConfigurationResult Result = new ConveyorConfigurationResult();

        public ConveyorConfiguration(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void WithDao<TDao>(ScopeType scopeType = ScopeType.Transient) where TDao : class, IDao<T>
        {
            InjectService<IDao<T>, TDao>(scopeType);
            Result.IsCustomDao = true;
        }

        public void WithService<TService>(ScopeType scopeType = ScopeType.Transient) where TService : class, IService<T>
        {
            InjectService<IService<T>, TService>(scopeType);
            Result.IsCustomService = true;
        }

        public void WithValidator<TValidator>(ScopeType scopeType = ScopeType.Transient) where TValidator : class, IValidator<T>
        {
            InjectService<IValidator<T>, TValidator>(scopeType);
            Result.IsCustomValidator = true;
        }

        public void UseQueryInnerEntitiesHandler<TQueryHandler>() where TQueryHandler : class, IQueryJoiningStrategy<T>
        {
            _serviceCollection.AddSingleton<IQueryJoiningStrategy<T>, TQueryHandler>();
            Result.IsCustomInnerEntitiesHandler = true;
        }

        internal void InjectService<TInterfaceService, TServiceImpl>(ScopeType scopeType) where TInterfaceService : class where TServiceImpl : class, TInterfaceService
        {
            switch (scopeType)
            {
                case ScopeType.Transient:
                    _serviceCollection.AddTransient<TInterfaceService, TServiceImpl>();
                    break;
                case ScopeType.Scoped:
                    _serviceCollection.AddScoped<TInterfaceService, TServiceImpl>();
                    break;
                case ScopeType.Singleton:
                    _serviceCollection.AddSingleton<TInterfaceService, TServiceImpl>();
                    break;
            }
        }

        public void UseBaseScopeType(ScopeType scopeType = ScopeType.Transient)
        {
            Result.BaseScopeType = scopeType;
        }
    }
}