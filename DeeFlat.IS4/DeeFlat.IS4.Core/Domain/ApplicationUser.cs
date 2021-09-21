using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeeFlat.IS4.Core.Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [Range(0, 200)]
        public int Age { get; set; }

        [StringLength(500)]
        public string AboutMe { get; set; }

    }
}
