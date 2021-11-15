using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Countries.GetCountries
{
    public class GetAllCountriesQueryHandler : BaseQueryHandlerAsync<GetAllCountriesQuery, IEnumerable<CountryDTO>>
    {
        private readonly DeeFlatDictDbContext _db;
       
        public GetAllCountriesQueryHandler(DeeFlatDictDbContext db)
        {
            _db = db;
        }

        public async override Task<IEnumerable<CountryDTO>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.Countries.Select(x => new CountryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return result;
        }
    }
}
