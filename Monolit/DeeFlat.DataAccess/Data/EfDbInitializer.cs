using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.DataAccess.Data
{
    public class EfDbInitializer
            : IDbInitializer
    {
        private readonly DeeFlatDBContext _db;

        public EfDbInitializer(DeeFlatDBContext db)
        {
            _db = db;
        }

        public void InitializeDb()
        {
            _db.Database.Migrate();
        }
    }
}
