using AutoMapper;
using DeeFlat.Abstractions.Abstractions;
using DeeFlat.IS4.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.GetUsers
{
    public class UserDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BornDate { get; set; }

        public string AboutMe { get; set; }

        public Guid CountryId { get; set; }

        public string CountryName { get; set; }

        public Guid CityId { get; set; }

        public string City { get; set; }

        public string[] Skils { get; set; }

        public string Email { get; set; }
    }

    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.Skils, sour => sour.MapFrom(x => x.Skills.Select(x => x.SkilName)));
        }

    }
}
