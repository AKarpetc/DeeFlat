using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Services.UserRolesServices.GetRoles
{
    public class RoleDTO : BaseDTO
    {
        public string Name { get; set; }

        public string NormalizedName { get; set; }


        public string Description { get; set; }
    }
}
