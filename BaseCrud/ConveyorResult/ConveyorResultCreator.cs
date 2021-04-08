using System.Collections.Generic;
using BaseCrud.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BaseCrud.ConveyorResult
{
    public class ConveyorResultCreator<T> : IConveyorResultCreator<T> where T : class, IEntity
    {
        public IActionResult GetSingleResult(IConveyorSingleResultBuilder<T> singleResultBuilder)
        {
            var conveyorResult = singleResultBuilder.GetConveyorResult() as IConveyorSingleResult<T>;

            ClearLoops(conveyorResult);

            return new OkObjectResult(conveyorResult);
        }

        public IActionResult GetMultiResult(IConveyorMultiResultBuilder<T> multiResultBuilder)
        {
            var conveyorResult = multiResultBuilder.GetConveyorResult() as IConveyorMultiResult<T>;

            ClearLoops(conveyorResult);

            return new OkObjectResult(conveyorResult);
        }
        
        private static void ClearLoops<TEntity>(IConveyorSingleResult<TEntity> conveyorResult) where TEntity : class, IEntity
        {
            var conveyorResultData = conveyorResult.Data;

            var serializeObject = JsonConvert.SerializeObject(conveyorResultData, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var deserializedObject = JsonConvert.DeserializeObject<TEntity>(serializeObject);

            conveyorResult.Data = deserializedObject;
        }
        
        private static void ClearLoops<TEntity>(IConveyorMultiResult<TEntity> conveyorResult) where TEntity : class, IEntity
        {
            var conveyorResultData = conveyorResult.Data;

            var serializeObject = JsonConvert.SerializeObject(conveyorResultData, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var deserializedObject = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(serializeObject);

            conveyorResult.Data = deserializedObject;
        }
    }
}