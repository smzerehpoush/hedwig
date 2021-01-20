using System.Threading.Tasks;
using Application.Users.Queries.GetUsersList;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetUsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        // [HttpPost]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesDefaultResponseType]
        // public async Task<IActionResult> Upsert(UpsertCategoryCommand command)
        // {
        //     var id = await Mediator.Send(command);
        //
        //     return Ok(id);
        // }
        //
        // [HttpDelete("{id}")]
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     await Mediator.Send(new DeleteCategoryCommand { Id = id });
        //
        //     return NoContent();
        // }
    }
}