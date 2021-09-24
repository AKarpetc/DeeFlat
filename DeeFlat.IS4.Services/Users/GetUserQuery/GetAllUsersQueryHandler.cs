using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUserQuery
{
    public class GetAllUsersQueryHandler : BaseQueryHandler<GetAllUsersQuery, IEnumerable<UsersDTO>>
    {
        private readonly IRepository<ApplicationUser> _usersRepository;

        public GetAllUsersQueryHandler(IRepository<ApplicationUser> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        protected override IEnumerable<UsersDTO> Handle(GetAllUsersQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
