using DeeFlat.Core.Domain;
using DeeFlat.Core.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.DataAccess.Data
{
    public class DeeFlatDBContext : DbContext
    {
        public DeeFlatDBContext(DbContextOptions<DeeFlatDBContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<CourseActivity> CourseActivities { get; set; }

        public virtual DbSet<Course> Course { get; set; }

        public virtual DbSet<CourseActivityType> CourseActivityTypes { get; set; }

        public virtual DbSet<ActivityTeacher> ActivityTeachers { get; set; }

        public virtual DbSet<CourseStatus> CourseStatuses { get; set; }

        public virtual DbSet<File> Files { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<GroupStatus> GroupStatuses { get; set; }

        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual DbSet<UserMark> UserMarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStatus>().HasData(
            new CourseStatus
            {
                Name = "В разработке",
                Id = Core.Domain.CourseStatuses.InWork
            },
            new CourseStatus
            {
                Name = "Новый",
                Id = Core.Domain.CourseStatuses.New
            },
            new CourseStatus
            {
                Name = "Опубликован",
                Id = Core.Domain.CourseStatuses.Published,
                Created = DateTime.Now
            },
            new CourseStatus
            {
                Name = "Закрыт",
                Id = Core.Domain.CourseStatuses.Closed,
                Created = DateTime.Now
            });

            modelBuilder.Entity<CourseActivityType>().HasData(
                new CourseActivityType
                {
                    Id = Core.Domain.CourseActivityTypes.HomeTask,
                    Name = "Домашнее задание",
                    Created = DateTime.Now
                },
                new CourseActivityType
                {
                    Id = Core.Domain.CourseActivityTypes.Lection,
                    Name = "Лекция",
                    Created = DateTime.Now
                },
                new CourseActivityType
                {
                    Id = Core.Domain.CourseActivityTypes.Practice,
                    Name = "Практика",
                    Created = DateTime.Now
                });

            modelBuilder.Entity<GroupStatus>().HasData(
               new GroupStatus
               {
                   Id = Core.Domain.GroupStatuses.Closed,
                   Name = "Завершено",
                   Created = DateTime.Now
               },
               new GroupStatus
               {
                   Id = Core.Domain.GroupStatuses.Complectation,
                   Name = "Комплектация группы",
                   Created = DateTime.Now
               },
               new GroupStatus
               {
                   Id = Core.Domain.GroupStatuses.Complectated,
                   Name = "Группа укомплектована",
                   Created = DateTime.Now
               },
                new GroupStatus
                {
                    Id = Core.Domain.GroupStatuses.Teaching,
                    Name = "В процессе обучения",
                    Created = DateTime.Now
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
