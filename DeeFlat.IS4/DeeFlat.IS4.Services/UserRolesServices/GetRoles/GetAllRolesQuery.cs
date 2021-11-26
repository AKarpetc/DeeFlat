using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.UserRolesServices.GetRoles
{
    public class GetAllRolesQuery : IQuery<IEnumerable<RoleDTO>>
    {
    }
}
