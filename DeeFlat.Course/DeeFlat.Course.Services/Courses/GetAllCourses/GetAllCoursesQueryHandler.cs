using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.Course.Core.Domain;
using DeeFlat.Course.Services.Courses.GetAllCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DBCource = DeeFlat.Course.Core.Domain.Course;

namespace DeeFlat.Course.Services.Courses.GetAllCourses
{
    public class GetAllCoursesQueryHandler : BaseQueryHandlerAsync<GetAllCoursesQuery, IEnumerable<GetCourseDTO>>
    {
        IRepository<DBCource> _courseRepository;
        IRepository<CourseActivity> _activityRepository;

        public GetAllCoursesQueryHandler(IRepository<DBCource> courseRepository, IRepository<CourseActivity> activityRepository)
        {
            _courseRepository = courseRepository;
            _activityRepository = activityRepository;
        }

        public async override Task<IEnumerable<GetCourseDTO>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var activities = await _activityRepository.GetAllAsync();

            var collection = (await _courseRepository.GetAllAsync()).Select(x => new GetCourseDTO
            {
                Description = x.Description,
                Name = x.Name,
                StatusName = x.Status.ToString(),
                CountActivities = activities.Where(a => a.CourseId == x.Id).Count(),
            });

            return collection;
        }
    }
}
