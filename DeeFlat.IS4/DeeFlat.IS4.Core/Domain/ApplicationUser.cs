using Microsoft.AspNetCore.Identity;

namespace DeeFlat.IS4.Core.Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

    }
}
