using DeeFlat.IS4.DataAccess.Data;
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
    public class UserController : ControllerBase
    {
        DeeFlatIs4DbContext _db;
        public UserController(DeeFlatIs4DbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _db.Users.Select(x => new
            {
                x.Name,
                x.Surname,
                x.Email,
                x.BornDate,
                x.AboutMe,
                x.UserName

            });
            return Ok(result);
        }

    }
}
