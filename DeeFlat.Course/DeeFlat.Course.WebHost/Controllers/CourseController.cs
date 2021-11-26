using DeeFlat.Course.Services.Courses.AddCourse;
using DeeFlat.Course.Services.Courses.GetAllCourses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.Course.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var collection = await _mediator.Send(new GetAllCoursesQuery());

            return Ok(collection);
        }

        [HttpPost]
        public async Task Add(AddCourseCommand model)
        {
            await _mediator.Send(model);
        }
    }
}
