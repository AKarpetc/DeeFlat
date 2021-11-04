using DeeFlat.Dictionaries.DataAccess.Data;
using DeeFlat.Groups.Services.Groups.AddGroupCommand;
using DeeFlat.Groups.WebHost.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DeeFlat.Groups.WebHost
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
            Console.WriteLine(nameof(conectionString) + " " + conectionString);

            services.AddDbContext<DeeFlatGroupDbContext>(option =>
            {
                option.UseNpgsql(conectionString);
                option.UseLazyLoadingProxies();
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeeFlat.Groups.WebHost", Version = "v1" });
            });

            services.AddMediatR(typeof(AddGroupCommand));
            services.AddValidatorsFromAssembly(typeof(AddGroupCommand).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeeFlat.Groups.WebHost v1"));
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
