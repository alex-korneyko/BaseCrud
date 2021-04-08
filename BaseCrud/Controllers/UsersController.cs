using BaseCrud.ConveyorResult;
using BaseCrud.Domain;
using BaseCrud.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : BaseCrudController<AppUser>
    {
        public UsersController(IValidator<AppUser> validator, IConveyorResultCreator<AppUser> conveyorResultCreator) 
            : base(validator, conveyorResultCreator)
        {
        }
    }
}