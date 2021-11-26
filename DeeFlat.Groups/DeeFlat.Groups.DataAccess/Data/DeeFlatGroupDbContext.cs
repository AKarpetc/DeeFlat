using DeeFlat.Groups.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeeFlat.Dictionaries.DataAccess.Data
{
    public class DeeFlatGroupDbContext : DbContext
    {
        public DeeFlatGroupDbContext(DbContextOptions<DeeFlatGroupDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<GroupStatus> GroupStatuses { get; set; }

        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual DbSet<UserMark> UserMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupStatus>().HasData(
              new GroupStatus
              {
                  Id = DeeFlat.Groups.Core.Domain.GroupStatuses.Closed,
                  Name = "Завершено",
                  Created = DateTime.Now
              },
              new GroupStatus
              {
                  Id = DeeFlat.Groups.Core.Domain.GroupStatuses.Complectation,
                  Name = "Комплектация группы",
                  Created = DateTime.Now
              },
              new GroupStatus
              {
                  Id = DeeFlat.Groups.Core.Domain.GroupStatuses.Complectated,
                  Name = "Группа укомплектована",
                  Created = DateTime.Now
              },
               new GroupStatus
               {
                   Id = DeeFlat.Groups.Core.Domain.GroupStatuses.Teaching,
                   Name = "В процессе обучения",
                   Created = DateTime.Now
               });
        }
    }
}
