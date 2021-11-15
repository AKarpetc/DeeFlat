using DeeFlat.Abstractions.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Countries.GetCountries
{
    public class GetAllCountriesQuery : IQuery<IEnumerable<CountryDTO>>
    {
    }
}
