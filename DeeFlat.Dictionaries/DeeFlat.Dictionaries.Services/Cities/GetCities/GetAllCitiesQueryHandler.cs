using DeeFlat.Abstractions.CQRS;
using DeeFlat.Dictionaries.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.Services.Cities.GetCities
{
    public class GetAllCitiesQueryHandler : BaseQueryHandlerAsync<GetAllCitiesQuery, IEnumerable<CityDTO>>
    {
        private readonly DeeFlatDictDbContext _db;

        public GetAllCitiesQueryHandler(DeeFlatDictDbContext db)
        {
            _db = db;
        }

        public async override Task<IEnumerable<CityDTO>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _db.Cities.Select(x => new CityDTO
            {
                Id = x.Id,
                Name = x.Name,
                CountryId = x.CountryId
            }).ToListAsync();

            return result;
        }
    }
}
