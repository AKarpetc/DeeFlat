using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.WebHost.Models
{
    public class OpenIdConnectSettings
    {
        public string Authority { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string ResponseType { get; set; }

        public string[] Scopes { get; set; }
    }
}
