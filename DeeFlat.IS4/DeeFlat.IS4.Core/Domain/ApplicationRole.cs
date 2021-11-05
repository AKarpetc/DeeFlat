using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Core.Domain
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }

        public ApplicationRoleTypes Type { get; set; }
    }

    public enum ApplicationRoleTypes
    {
        ForChoose,
        Hidden,
    }
}
