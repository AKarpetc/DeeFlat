using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;

namespace DeeFlat.Groups.Services.Groups.GetGroupsQuery
{
    public class GetGroupsQueryHandler : BaseQueryHandler<GetGroupsQuery, IEnumerable<GroupDTO>>
    {
        private readonly DeeFlatGroupDbContext _db;

        public GetGroupsQueryHandler(DeeFlatGroupDbContext db)
        {
            _db = db;
        }

        protected override IEnumerable<GroupDTO> Handle(GetGroupsQuery request)
        {
            return _db.Groups.Where(x => x.IsDeleted == false).Select(x => new GroupDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = new DropDownDTO()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            }).OrderBy(x => x.Name);
        }
    }
}
