using DeeFlat.IS4.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeeFlat.IS4.DataAccess.Data
{
    public class DeeFlatIs4DbContext : IdentityDbContext<ApplicationUser>
    {
        public DeeFlatIs4DbContext(DbContextOptions<DeeFlatIs4DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserSkill> UserSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
