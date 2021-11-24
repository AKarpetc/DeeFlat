using AutoMapper;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.UserRolesServices.GetRoles
{
    public class GetAllRolesQueryHandler : BaseQueryHandlerAsync<GetAllRolesQuery, IEnumerable<RoleDTO>>
    {
        private readonly IRepository<ApplicationRole> _userRepository;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IRepository<ApplicationRole> userRepository, RoleManager<ApplicationRole> roleManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
        }

        public async override Task<IEnumerable<RoleDTO>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {


            return (_roleManager.Roles.Where(x => x.Type == ApplicationRoleTypes.ForChoose))
                                          .Select(x => new RoleDTO
                                          {
                                              Id = x.Id,
                                              Name = x.Name,
                                              Description = x.Description,
                                              NormalizedName = x.NormalizedName
                                          });
        }
    }
}
