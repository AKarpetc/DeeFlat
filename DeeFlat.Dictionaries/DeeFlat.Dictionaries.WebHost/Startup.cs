using DeeFlat.Abstractions.Contracts;
using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Dictionaries.Services.Skills.GetSkills;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeeFlat.Dictionaries.WebHost
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
            Console.WriteLine(nameof(conectionString) + " " + conectionString);//Ïðîâåðêà ÑonectionString

            services.AddDbContext<DeeFlatDictDbContext>(option =>
            {
                option.UseNpgsql(conectionString);
                option.UseLazyLoadingProxies();
            });

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

                    cfg.Message<ISkillMessage>(cfg => { });
                    cfg.AutoDelete = true;

                    cfg.ConfigureEndpoints(context);
                });
            });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeeFlat.Dictionaries.WebHost", Version = "v1" });
            });

            services.AddMediatR(typeof(SkillDTO));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeeFlat.Dictionaries.WebHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
