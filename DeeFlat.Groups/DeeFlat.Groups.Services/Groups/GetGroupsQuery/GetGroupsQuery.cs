using DeeFlat.Abstractions.CQRS;
using System.Collections.Generic;

namespace DeeFlat.Groups.Services.Groups.GetGroupsQuery
{
    public class GetGroupsQuery : IQuery<IEnumerable<GroupDTO>>
    {
    }
}
