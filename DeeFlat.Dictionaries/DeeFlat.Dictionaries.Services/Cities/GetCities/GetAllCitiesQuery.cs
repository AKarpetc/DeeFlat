using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Cities.GetCities
{
    public class GetAllCitiesQuery : IQuery<IEnumerable<CityDTO>>
    {
        public GetAllCitiesQuery(Guid countryId)
        {
            CountryId = countryId;
        }
        public Guid CountryId { get; set; }
    }
}
