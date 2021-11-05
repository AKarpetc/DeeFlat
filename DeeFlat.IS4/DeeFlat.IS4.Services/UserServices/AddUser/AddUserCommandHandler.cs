using AutoMapper;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.AddUserCommand
{
    /// <summary>
    /// TODO для теста после добавление фронтенда, будет работать только через обновление, так как добавление происходит через регистрацию пользователей
    /// </summary>
    public class AddUserCommandHandler : BaseCommandHandler<AddUserCommand>
    {
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IRepository<ApplicationUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        protected override async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            await _userRepository.CreateAsync(user);
        }
    }
}
