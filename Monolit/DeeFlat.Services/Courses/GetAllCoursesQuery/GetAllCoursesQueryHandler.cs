using DeeFlat.Core.Abstractions;
using DeeFlat.Core.DTO;
using DeeFlat.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;

namespace DeeFlat.Services.Courses.GetAllCoursesQuery
{
    public class GetAllCoursesQueryHandler : BaseQueryHandler<GetAllCoursesQuery, IEnumerable<CourseDTO>>
    {
        private readonly DeeFlatDBContext _db;

        public GetAllCoursesQueryHandler(DeeFlatDBContext db)
        {
            _db = db;
        }

        protected override IEnumerable<CourseDTO> Handle(GetAllCoursesQuery request)
        {
            var result = _db.Course.Select(x => new CourseDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Status = new EnumDropDownDTO()
                {
                    Id = (int)x.StatusId,
                    Name = x.Status.Name
                }
            });

            return result;
        }
    }
}
