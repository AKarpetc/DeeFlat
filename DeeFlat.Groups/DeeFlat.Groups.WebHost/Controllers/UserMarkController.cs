using DeeFlat.Groups.Services.UserMarks.SetUserMark;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeeFlat.Groups.WebHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserMarkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserMarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SetUserMarkCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
