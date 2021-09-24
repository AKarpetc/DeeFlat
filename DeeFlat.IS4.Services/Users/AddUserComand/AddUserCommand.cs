using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.Users.AddUserComand
{
    public class AddUserCommand : ICommand
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime BornDate { get; set; }

        [StringLength(500)]
        public string AboutMe { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string[] Skils { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
