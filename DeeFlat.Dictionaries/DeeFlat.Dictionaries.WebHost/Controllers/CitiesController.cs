using DeeFlat.Dictionaries.Services.Cities.GetCities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid countryId)
        {
            var result = await _mediator.Send(new GetAllCitiesQuery(countryId));
            return Ok(result);
        }

    }
}
