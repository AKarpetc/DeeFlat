using DeeFlat.Core.Abstractions;
using DeeFlat.Services.Courses.AddCourseCommand;
using DeeFlat.Services.Courses.GetAllCoursesQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CourcesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourcesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        [Authorize]
        [HttpGet("GetAuthorized")]
        public async Task<IActionResult> GetAuthorized()
        {
            return Ok(await _mediator.Send(new GetAllCoursesQuery()));
        }

        [HttpPost]
        public async Task Post(AddCourseCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
