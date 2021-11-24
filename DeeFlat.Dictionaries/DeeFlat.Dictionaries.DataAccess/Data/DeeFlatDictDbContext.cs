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
            //this.Database.EnsureDeleted();
        }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<City> Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var country1Id = Guid.NewGuid();
            var country2Id = Guid.NewGuid();
            var country3Id = Guid.NewGuid();


            var countries = new List<Country>{
            new Country
            {
                Id=country1Id ,
                Name="Россия",
            },
            new Country
            {
                Id=country2Id ,
                Name="Казахстан",

            },
            new Country
            {
                Id=country3Id ,
                Name="Украина",

            },
            };

            var cities = new List<City>()
            {   new City
                    {
                        CountryId=country1Id,
                        Name="Москва"
                    },
                    new City
                    {
                        CountryId=country1Id,
                        Name="Санкт-Петербург"
                    },
                    new City
                    {   CountryId=country1Id,
                        Name="Волгоград"
                    },
                    new City
                    {
                        CountryId=country2Id,
                        Name="Алматы"
                    },
                    new City
                    {
                        CountryId=country2Id,
                        Name="Караганда"
                    },
                    new City
                    {
                        CountryId=country2Id,
                        Name="Астана"
                    },
                     new City
                    {
                        CountryId=country3Id,
                        Name="Киев"
                    },
                    new City
                    {
                        CountryId=country3Id,
                        Name="Днепр"
                    },
                    new City
                    {
                        CountryId=country3Id,
                        Name="Одесса"
                    }
            };


            var skills = new List<Skill>{
            new Skill()
            { 
               Id=Guid.NewGuid(),
               Name="C#",

            },
            new Skill()
            {
               Id=Guid.NewGuid(),
               Name="JavaScript",

            },
            new Skill()
            {
               Id=Guid.NewGuid(),
               Name="HTML",

            },
            new Skill()
            {
               Id=Guid.NewGuid(),
               Name=".NET",

            }
          };

            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<City>().HasData(cities);
            modelBuilder.Entity<Skill>().HasData(skills);


            base.OnModelCreating(modelBuilder);
        }
    }
}
