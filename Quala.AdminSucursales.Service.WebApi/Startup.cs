using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Quala.AdminSucursales.Application.DTO;
using Quala.AdminSucursales.Application.Interface;
using Quala.AdminSucursales.Application.Main;
using Quala.AdminSucursales.Domain.Core;
using Quala.AdminSucursales.Domain.Entity;
using Quala.AdminSucursales.Domain.Interface;
using Quala.AdminSucursales.Infraestructure.Data;
using Quala.AdminSucursales.Infraestructure.Interface;
using Quala.AdminSucursales.Infraestructure.Repository;
using Quala.AdminSucursales.Service.WebApi;
using Quala.AdminSucursales.Transversal.Common;
using Quala.AdminSucursales.Transversal.Mapper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace Quala.AdminSucursales.Service.WebApi
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
            services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
            services.AddControllers();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<ISucursalApplication, SucursalApplication>();
            services.AddScoped<ISucursalDomain, SucursalDomain>();
            services.AddScoped<ISucursalRepository, SucursalRepository>();
            services.AddScoped<IMonedaApplication, MonedaApplication>();
            services.AddScoped<IMonedaDomain, MonedaDomain>();
            services.AddScoped<IMonedaRepository, MonedaRepository>();

            // Register the swagger

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = "Quala WebApi Sucursales",
                    Version = groupName,
                    Description = "Sucursales API",
                    Contact = new OpenApiContact
                    {
                        Name = " [Oscar Fernandez]",
                        Email = "ocafer9005@hotmail.com",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Sucursales V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
