// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DeeFlat.IS4.Core.Domain;
using DeeFlat.IS4.DataAccess.Data;
using Microsoft.OpenApi.Models;
using System;
using DeeFlat.Abstractions.Repositories;
using DeeFlat.IS4.DataAccess;
using MediatR;
using DeeFlat.IS4.Services.Users.GetUsers;

namespace DeeFlat.IS4.WebHost
{
    public class Startup
    {
        public IWebHostEnvironment _environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            this._environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            string confConectionString = Configuration.GetConnectionString("DefaultConnectionStrings");
            var envConectionString = Environment.GetEnvironmentVariable("DB_ConectionString");
            var conectionString = envConectionString;

#if DEBUG
            conectionString = confConectionString;
#endif
            Console.WriteLine(nameof(conectionString) + " " + conectionString);//Проверка СonectionString


            services.AddDbContext<DeeFlatIs4DbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(conectionString);
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DeeFlatIs4DbContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            // По скольку модели IDentity не унаследованы от BaseEntity либо писать свой репозиторий для каждого объекта либо использовать БД
            // поскольку микросервис содержит мало классов решил использовать отдельные репозитории для каждого сервиса

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            services.AddAutoMapper(typeof(Startup).Assembly, typeof(UserDTO).Assembly);



            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    // register your IdentityServer with Google at https://console.developers.google.com
                    // enable the Google+ API
                    // set the redirect URI to https://localhost:5001/signin-google
                    options.ClientId = "copy client ID from Google here";
                    options.ClientSecret = "copy client secret from Google here";
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeeFlat.IS4.WebHost", Version = "v1" });
            });

            services.AddMediatR(typeof(UserDTO));
        }

        public void Configure(IApplicationBuilder app, DeeFlatIs4DbContext db)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeeFlat.WebHost v1"));
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

        }
    }
}