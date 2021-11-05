using DeeFlat.IS4.WebHost.Models;
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
        [HttpGet("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            return Ok();
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
