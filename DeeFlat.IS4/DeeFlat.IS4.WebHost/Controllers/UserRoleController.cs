using DeeFlat.IS4.DataAccess.Data;
using DeeFlat.IS4.Services.UserRolesServices.GetRoles;
using DeeFlat.IS4.Services.Users;
using DeeFlat.IS4.Services.Users.AddUserCommand;
using DeeFlat.IS4.Services.Users.GetUsers;
using DeeFlat.IS4.WebHost.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.IS4.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }

        [HttpGet("GetFreeRoles")]
        public async Task<ActionResult> GetFreeRoles(Guid userId)
        {
            return Ok();
        }

        [HttpGet("GetUserRoles")]
        public async Task<ActionResult> GetUserRoles(Guid userId)
        {
            return Ok();
        }

        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole(ChnageRoleReques model)
        {
            return Ok();
        }

        [HttpPost("RemoveRole")]
        public async Task<ActionResult> RemoveRole(ChnageRoleReques model)
        {
            return Ok();
        }
    }
}
