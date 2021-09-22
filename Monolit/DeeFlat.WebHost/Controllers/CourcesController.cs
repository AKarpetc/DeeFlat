using DeeFlat.Core.Abstractions;
using DeeFlat.Services.Courses.AddCourseCommand;
using DeeFlat.Services.Courses.GetAllCoursesQuery;
using DeeFlat.WebHost.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
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

        [HttpPost("GetQuery")]
        public async Task<IActionResult> GetQuery(RequestModel model)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);

            var result = await client.GetAsync(model.Url);

            return Ok(await result.Content.ReadAsStringAsync());
        }
    }
}
