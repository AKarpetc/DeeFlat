using AutoMapper;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.UpdateUser
{
    public class UpdateUserCommandHandler : BaseCommandHandler<UpdateUserCommand>
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IRepository<ApplicationUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        protected async override Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userRepository.GetByIdAsync(request.Id);

            var user = _mapper.Map(request, oldUser);

            user.Skills.Clear();

            //foreach (var skill in request.Skills)
            //{
            //    user.Skills.Add(skill);
            //}

            await _userRepository.UpdateAsync(user);
        }
    }
}
