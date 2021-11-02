using DeeFlat.DataAccess.Data;
using DeeFlat.Services.Courses.GetAllCoursesQuery;
using DeeFlat.WebHost.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;

namespace DeeFlat.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string confConectionString = Configuration.GetConnectionString("DefaultConnectionStrings");
            var envConectionString = Environment.GetEnvironmentVariable("DB_ConectionString");
            var conectionString = envConectionString;

#if DEBUG
            conectionString = confConectionString;
#endif
            Console.WriteLine(nameof(conectionString) + " " + conectionString);//Проверка СonectionString

            services.AddScoped<IDbInitializer, EfDbInitializer>();
            services.AddDbContext<DeeFlatDBContext>(option =>
            {
                option.UseNpgsql(conectionString);
                option.UseLazyLoadingProxies();
            });

            IdentityModelEventSource.ShowPII = true;

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            var confOpenId = Configuration.GetSection("OpenIdConnectSettings").Get<OpenIdConnectSettings>();

            services.AddAuthentication("Bearer")
             .AddJwtBearer("Bearer", options =>
             {
                 options.Authority = "https://localhost:5001";
                 options.Audience = "test-api";
                 options.BackchannelHttpHandler = httpClientHandler;
                 options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                 {
                     ValidateAudience = false
                 };
             });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope2", "scope1", "api1");
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeeFlat.WebHost", Version = "v1" });
            });

            services.AddMediatR(typeof(CourseDTO));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (true || env.IsDevelopment())//TODO  для теста в контейнере
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeeFlat.WebHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                         .RequireAuthorization();
            });

            dbInitializer.InitializeDb();
        }
    }
}
