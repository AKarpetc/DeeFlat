using AutoMapper;
using AutoMapper.QueryableExtensions;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.DataAccess.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUsers
{
    public class GetAllUsersQueryHandler : BaseQueryHandlerAsync<GetAllUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IRepository<ApplicationUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async override Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _mapper.Map<IEnumerable<UserDTO>>(await _userRepository.GetAllAsync());

            return users;
        }


    }
}
