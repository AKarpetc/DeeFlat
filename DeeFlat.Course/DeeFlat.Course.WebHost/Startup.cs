using DeeFlat.Abstractions.Repositories;
using DeeFlat.Course.Core.Domain;
using DeeFlat.Course.DataAccess.DBSettings;
using DeeFlat.Course.DataAccess.Repositories;
using DeeFlat.Course.Services.Courses.AddCourse;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DeeFlat.Course.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        const string SpaClient = "_spaClient";

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<DeeFlatCourseDBSettings>(
                Configuration.GetSection(nameof(DeeFlatCourseDBSettings)));

            services.AddSingleton<IDeeFlatCourseDBSettings>(sp =>
                sp.GetRequiredService<IOptions<DeeFlatCourseDBSettings>>().Value);

            services.AddScoped(typeof(IRepository<>), typeof(MongoDBRepository<>));

            var massTransitSection = Configuration.GetSection("MassTransit");
            var url = massTransitSection.GetValue<string>("Url");
            var host = massTransitSection.GetValue<string>("Host");
            var userName = massTransitSection.GetValue<string>("UserName");
            var password = massTransitSection.GetValue<string>("Password");

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host($"rabbitmq://{url}/{host}", configurator =>
                    {
                        configurator.Username(userName);
                        configurator.Password(password);
                    });

                    cfg.AutoDelete = true;

                    cfg.ConfigureEndpoints(context);
                });
            });


            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer("Bearer", options =>
             {
                 options.Authority = "https://localhost:5001";
                 // options.Audience = "dictionary-api api openid profile";
                 options.BackchannelHttpHandler = httpClientHandler;
                 //options.RequireHttpsMetadata = false;
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
                    policy.RequireClaim("dictionary-api");
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: SpaClient,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000");
                                  });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeeFlat.Dictionaries.WebHost", Version = "v1" });
            });

            services.AddMediatR(typeof(AddCourseCommand));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRepository<CourseStatus> statusRepostory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeeFlat.Dictionaries.WebHost v1"));

            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
