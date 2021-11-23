// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.DataAccess.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DeeFlat.IS4.WebHost
{
    public class SeedData
    {
        private static RoleManager<ApplicationRole> roleManager;
        private static void AddRole(ApplicationRole role)
        {
            var existedRole = roleManager.FindByNameAsync(role.Name).Result;
            if (existedRole == null)
            {
                var result = roleManager.CreateAsync(new ApplicationRole
                {
                    Name = role.Name,
                    NormalizedName = role.NormalizedName,
                    Description = role.Description
                }).Result;

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
            }
            else
            {
                Log.Debug(role.Name + "is already exist");
            }

        }

        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<DeeFlatIs4DbContext>(options =>
               options.UseNpgsql(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DeeFlatIs4DbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<DeeFlatIs4DbContext>();

                    //  context.Database.EnsureDeleted();

                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    var alice = userMgr.FindByNameAsync("alice").Result;




                    if (alice == null)
                    {
                        alice = new ApplicationUser
                        {
                            UserName = "alice",
                            Email = "AliceSmith@email.com",
                            AboutMe = "Закончила университет, хочу получить новые навыки и пройти все возможные курсы для того что бы устроится на работу мечты",
                            BornDate = DateTime.Now.AddYears(-20),
                            City = "Астана",
                            CityId = new Guid("795321fb-2708-4695-8148-fd75e07e5292"),
                            CountryId = new Guid("197f38bf-4d94-44ec-bf11-37040e6c6880"),
                            CountryName = "Казахстан",
                            Skills = new List<UserSkill> { new UserSkill { Id = new Guid("96be8c8a-8f39-43b4-b0fe-47b3030724bb"), SkilName = "C#" } },
                            PhoneNumber = "+77778880077",
                            EmailConfirmed = true,
                            Name = "Алис",
                            Surname = "Баранкина"
                        };
                        var result = userMgr.CreateAsync(alice, "Pass123$").Result;


                        result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.NickName, "alice"),
                            new Claim(JwtClaimTypes.Name, "alice"),
                            new Claim(JwtClaimTypes.GivenName, "Алис"),
                            new Claim("full_name", "Алис Баранкина"),
                            new Claim(JwtClaimTypes.FamilyName, "Баранкина"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("alice created");
                    }
                    else
                    {

                       // context.UserSkills.RemoveRange(context.UserSkills.ToList());
                     //   userMgr.DeleteAsync(alice).Wait();

                        Log.Debug("alice already exists");
                    }

                    var bob = userMgr.FindByNameAsync("bob").Result;
                    if (bob == null)
                    {
                        bob = new ApplicationUser
                        {
                            UserName = "bob",
                            Email = "BobSmith@email.com",
                            EmailConfirmed = true,
                            Name = "Боб",
                            Surname = "Марли"
                        };
                        var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("bob created");
                    }
                    else
                    {
                        Log.Debug("bob already exists");
                    }

                    AddRole(new ApplicationRole
                    {
                        Name = "Student",
                        NormalizedName = "Студент",
                        Description = "Если Вы хотите учиться на курсах данной платформа"
                    });

                    AddRole(new ApplicationRole
                    {
                        Name = "Teacher",
                        NormalizedName = "Преподаватель",
                        Description = "Если Вы хотите вести добавлять курсы и учить других студентов",
                        Type = ApplicationRoleTypes.ForChoose
                    });

                    AddRole(new ApplicationRole
                    {
                        Name = "Admin",
                        NormalizedName = "Администратор",
                        Description = "Роль для администраторов системы",
                        Type = ApplicationRoleTypes.Hidden
                    });
                }
            }
        }
    }
}
