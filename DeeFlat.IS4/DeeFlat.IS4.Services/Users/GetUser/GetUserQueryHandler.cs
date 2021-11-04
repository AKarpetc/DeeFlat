using AutoMapper;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.Services.Users.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUser
{
    public class GetUserQueryHandler : BaseQueryHandlerAsync<GetUserQuery, UserDTO>
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IRepository<ApplicationUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async override Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetFirstWhereAsync(x => x.UserName == request.UserName);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
