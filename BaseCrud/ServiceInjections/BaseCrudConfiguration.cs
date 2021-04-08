using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseCrud.ServiceInjections
{
    public class BaseCrudConfiguration
    {
        private readonly IServiceCollection _collection;

        public BaseCrudConfiguration(IServiceCollection collection)
        {
            _collection = collection;
        }

        public void AddDbContext<T>() where T : DbContext
        {
            _collection.AddDbContext<T>();

            ServiceConfiguration.DbContextImplementation = typeof(T);
        }
    }
}