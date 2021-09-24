using DeeFlat.Dictionaries.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.DataAccess.Data
{
    public class DeeFlatDictDbContext : DbContext
    {
        public DeeFlatDictDbContext(DbContextOptions<DeeFlatDictDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Skill> Skills { get; set; }
    }
}
