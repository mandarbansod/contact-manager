using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ContactManager.Business;
using ContactManager.Controllers.Core;
using ContactManager.Data;
using ContactManager.Mappers;
using ContactManager.Respository;
using ContactManager.Respository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ContactManager.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(
                    new JsonSerializerSettings
                    {
                        //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc
                    },
                    ArrayPool<char>.Shared));
            }).AddApplicationPart(Assembly.Load(new AssemblyName("ContactManager.Controllers")));

            // Initializes the Swagger for the Documentation
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Contact Manager API",
                    Description = "API to handle Contact Data",
                    TermsOfService = "None"
                });
            });

            services.ConfigureSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();
            });

            services.AddSingleton<IConfigurationRoot>(provider => Configuration);

            services.AddDistributedMemoryCache();

            services.AddEntityFrameworkSqlServer();


            services.AddScoped<IContactManagerContext, ContactManagerContextSql>();
            services.AddScoped<IContactManager, ContactManager.Business.Implementation.ContactManager>();
            services.AddScoped<IContactRepository, ContactRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) //, IApplicationEnvironment appEnv)
        {
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            if (env.IsDevelopment())
            {
                //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                //loggerFactory.AddDebug();
            }

            // Add the Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger/ui";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Manager API");
            });
            app.UseMiddleware<ExceptionHandlingMiddleware>();

           

            ConfigureMappers();

            app.UseMvc();
        }

        private void ConfigureMappers()
        {
            new DtoToDomainMapper().ConfigMapper();
            new DomainToEntityMapper().ConfigMapper();
        }

    }
}