using DeeFlat.Dictionaries.Services.Skills.AddSkill;
using DeeFlat.Dictionaries.Services.Skills.GetSkills;
using DeeFlat.Dictionaries.Services.Skills.UpdateSkill;
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
    public class SkillController : ControllerBase
    {
        IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllSkillsQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddSkillCommand skill)
        {
            var result = await _mediator.Send(skill);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateSkillCommand skill)
        {
            var result = await _mediator.Send(skill);
            return Ok(result);
        }
    }
}
