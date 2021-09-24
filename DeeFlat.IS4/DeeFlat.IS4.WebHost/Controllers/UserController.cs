﻿using DeeFlat.IS4.DataAccess.Data;
using DeeFlat.IS4.Services.Users.AddUserCommand;
using DeeFlat.IS4.Services.Users.GetUserQuery;
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
    public class UserController : ControllerBase
    {
        IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUserCommand user)
        {
            var result = await _mediator.Send(user);
            return Ok(result);
        }

    }
}
