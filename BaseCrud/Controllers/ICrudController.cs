using System.Collections.Generic;
using BaseCrud.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.Controllers
{
    public interface ICrudController<in TEntity> where TEntity : class, IEntity
    {
        IActionResult GetAll();
        IActionResult GetRange(IEnumerable<long> idRange);
        IActionResult GetById(long id);
        IActionResult Add(TEntity entity);
        IActionResult AddRange(IEnumerable<TEntity> entities);
        IActionResult Update(TEntity entity);
        IActionResult UpdateRange(IEnumerable<TEntity> entities);
        IActionResult Delete(TEntity entity);
        IActionResult DeleteRange(IEnumerable<TEntity> entities);
    }
}