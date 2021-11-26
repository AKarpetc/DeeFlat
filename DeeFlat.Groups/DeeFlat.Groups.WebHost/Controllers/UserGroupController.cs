using DeeFlat.Groups.Services.UserGroups.AddUsersInGroupCommand;
using DeeFlat.Groups.Services.UserGroups.RemoveUsersFromGroupCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeeFlat.Groups.WebHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUsersInGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
       
        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveUsersFromGroupCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
