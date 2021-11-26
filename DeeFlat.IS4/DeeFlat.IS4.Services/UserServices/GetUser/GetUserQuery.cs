using AutoMapper;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.Services.Users.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUser
{
    public class GetUserQuery : IQuery<UserDTO>
    {
        public GetUserQuery(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }
    }
}
