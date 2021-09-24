using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUserQuery
{
    public class GetAllUsersQuery : IQuery<IEnumerable<UserDTO>>
    {

    }
}
