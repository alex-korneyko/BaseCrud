using System;
using BaseCrud.ConveyorResult;
using BaseCrud.DAO;
using BaseCrud.Domain;
using BaseCrud.Services;
using BaseCrud.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCrud.ServiceInjections
{
    public static class ServiceCollectionExtends
    {
        public static void AddCrudConveyor<T>(this IServiceCollection serviceCollection, ScopeType scopeType = ScopeType.Transient) where T : class, IEntity
        {
            switch (scopeType)
            {
                case ScopeType.Transient:
                    AddTransientConveyorResultBuilder<T>(serviceCollection);
                    serviceCollection.AddTransient<IDao<T>, BaseDao<T>>();
                    serviceCollection.AddTransient<IService<T>, BaseService<T>>();
                    serviceCollection.AddTransient<IValidator<T>, BaseValidator<T>>();
                    break;
                case ScopeType.Scoped:
                    AddScopedConveyorResultBuilder<T>(serviceCollection);
                    serviceCollection.AddScoped<IDao<T>, BaseDao<T>>();
                    serviceCollection.AddScoped<IService<T>, BaseService<T>>();
                    serviceCollection.AddScoped<IValidator<T>, BaseValidator<T>>();
                    break;
                case ScopeType.Singleton:
                    AddSingletonConveyorResultBuilder<T>(serviceCollection);
                    serviceCollection.AddSingleton<IDao<T>, BaseDao<T>>();
                    serviceCollection.AddSingleton<IService<T>, BaseService<T>>();
                    serviceCollection.AddSingleton<IValidator<T>, BaseValidator<T>>();
                    break;
            }

            serviceCollection.AddSingleton<IQueryJoiningStrategy<T>, BaseQueryJoiningStrategy<T>>();
        }
        
        public static void AddCrudConveyor<T>(
            this IServiceCollection serviceCollection,
            Action<ConveyorConfiguration<T>> configuration) where T : class, IEntity
        {
            var conveyorConfiguration = new ConveyorConfiguration<T>(serviceCollection);

            configuration(conveyorConfiguration);

            switch (conveyorConfiguration.Result.BaseScopeType)
            {
                case ScopeType.Transient:
                    AddTransientConveyorResultBuilder<T>(serviceCollection);
                    break;
                case ScopeType.Scoped:
                    AddScopedConveyorResultBuilder<T>(serviceCollection);
                    break;
                case ScopeType.Singleton:
                    AddSingletonConveyorResultBuilder<T>(serviceCollection);
                    break;
            }

            if (!conveyorConfiguration.Result.IsCustomDao)
            {
                conveyorConfiguration.InjectService<IDao<T>, BaseDao<T>>(conveyorConfiguration.Result.BaseScopeType);
            }
            
            if (!conveyorConfiguration.Result.IsCustomService)
            {
                conveyorConfiguration.InjectService<IService<T>, BaseService<T>>(conveyorConfiguration.Result.BaseScopeType);
            }

            if (!conveyorConfiguration.Result.IsCustomValidator)
            {
                conveyorConfiguration.InjectService<IValidator<T>, BaseValidator<T>>(conveyorConfiguration.Result.BaseScopeType);
            }

            if (!conveyorConfiguration.Result.IsCustomInnerEntitiesHandler)
            {
                conveyorConfiguration.InjectService<IQueryJoiningStrategy<T>, BaseQueryJoiningStrategy<T>>(ScopeType.Singleton);
            }
        }

        public static void AddBaseCrud(this IServiceCollection collection, Action<BaseCrudConfiguration> configuration)
        {
            var baseCrudConfiguration = new BaseCrudConfiguration(collection);

            configuration(baseCrudConfiguration);

            collection.AddCrudConveyor<AppUser>(ScopeType.Scoped);
        }
        
        private static void AddTransientConveyorResultBuilder<T>(IServiceCollection serviceCollection) where T : class, IEntity
        {
            serviceCollection.AddTransient<IConveyorResultCreator<T>, ConveyorResultCreator<T>>();
            serviceCollection.AddTransient<IConveyorSingleResultBuilder<T>, ConveyorSingleResultBuilder<T>>();
            serviceCollection.AddTransient<IConveyorMultiResultBuilder<T>, ConveyorMultiResultBuilder<T>>();
        }
        
        private static void AddScopedConveyorResultBuilder<T>(IServiceCollection serviceCollection) where T : class, IEntity
        {
            serviceCollection.AddScoped<IConveyorResultCreator<T>, ConveyorResultCreator<T>>();
            serviceCollection.AddScoped<IConveyorSingleResultBuilder<T>, ConveyorSingleResultBuilder<T>>();
            serviceCollection.AddScoped<IConveyorMultiResultBuilder<T>, ConveyorMultiResultBuilder<T>>();
        }
        
        private static void AddSingletonConveyorResultBuilder<T>(IServiceCollection serviceCollection) where T : class, IEntity
        {
            serviceCollection.AddSingleton<IConveyorResultCreator<T>, ConveyorResultCreator<T>>();
            serviceCollection.AddSingleton<IConveyorSingleResultBuilder<T>, ConveyorSingleResultBuilder<T>>();
            serviceCollection.AddSingleton<IConveyorMultiResultBuilder<T>, ConveyorMultiResultBuilder<T>>();
        }
    }
}