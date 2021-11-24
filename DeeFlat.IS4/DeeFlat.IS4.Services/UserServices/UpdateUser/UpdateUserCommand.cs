using AutoMapper;
using DeeFlat.Abstractions.Abstractions;
using DeeFlat.Abstractions.CQRS;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.Services.Users.AddUserCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users
{
    public class UpdateUserCommand : BaseEntity, ICommand
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime BornDate { get; set; }

        [StringLength(500)]
        public string AboutMe { get; set; }

        public Guid CountryId { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public Skill[] Skills { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class UpdateUserCommandProfile : Profile
    {
        public UpdateUserCommandProfile()
        {
            CreateMap<UpdateUserCommand, ApplicationUser>()
                 .ForMember(dest => dest.Skills, sour => sour.MapFrom(x => x.Skills.Select(x => new UserSkill
                 {
                     SkilId = x.Id,
                     SkilName = x.Name
                 })));
        }
    }
}
