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
        [HttpGet("GetFreeRoles")]
        public async Task<ActionResult> GetRoles()
        {
            return Ok();
        }

        public async Task<ActionResult> GetFreeRoles(Guid userId)
        {
            return Ok();
        }

        public async Task<ActionResult> GetUserRoles(Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(Guid userId)
        {
            return Ok();
        }
    }
}
