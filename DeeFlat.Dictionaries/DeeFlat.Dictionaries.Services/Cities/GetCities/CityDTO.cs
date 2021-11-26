using DeeFlat.Abstractions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Cities.GetCities
{
    public class CityDTO : BaseDTO
    {
        public Guid CountryId { get; set; }

        public string Name { get; set; }
    }
}
