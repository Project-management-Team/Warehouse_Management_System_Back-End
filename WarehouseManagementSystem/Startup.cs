using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using WarehouseManagementSystem.Abstractions.Interfaces;
using WarehouseManagementSystem.Implementation.Services;
using WarehouseManagementSystem.Shared.Database.Context;

namespace WarehouseManagementSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WHManagmentSystemContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSwaggerGen();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWHCellService, WHCellService>();
            services.AddScoped<IWHZoneService, WHZoneService>();
            services.AddScoped<IWHLockerService, WHLockerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITruckService, TruckService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<Exception>();
                var exception = exceptionHandlerPathFeature.Message;

                var result = JsonConvert.SerializeObject(new { error = exception });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API");
                });
            }
            else
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Warehouse API");
                });
            }
        }
    }
}
