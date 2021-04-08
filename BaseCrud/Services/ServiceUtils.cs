using System;
using System.Linq;
using BaseCrud.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaseCrud.Services
{
    public static class ServiceUtils
    {
        public static DbSet<T> GetDbSet<T>(DbContext context) where T : class, IEntity
        {
            var propertyInfos = context.GetType().GetProperties();
            
            var contextDbSetPropertyInfo = propertyInfos
                .FirstOrDefault(propInfo => propInfo.PropertyType.GenericTypeArguments.Length == 1 
                                            && propInfo.PropertyType.GenericTypeArguments[0] == typeof(T));

            if (contextDbSetPropertyInfo == null)
            {
                throw new ApplicationException($"Property not found in DbContext with generic: '{typeof(T)}'");
            }

            var values = contextDbSetPropertyInfo.GetValue(context) as DbSet<T>;

            return values;
        }
    }
}