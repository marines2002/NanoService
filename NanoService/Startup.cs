using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NanoService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DogService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/dogs/{id:int}", async context =>
                {
                    var countryService = context.Request.HttpContext.RequestServices.GetRequiredService<DogService>();

                    var id = int.Parse((string)context.Request.RouteValues["id"]);
                    var country = await countryService.Get(id);
                    var response = country != null ? JsonSerializer.Serialize(country) : "No dog found";

                    await context.Response.WriteAsync(response);
                });

                endpoints.MapGet("/dogs", async context =>
                {
                    var countryService = context.Request.HttpContext.RequestServices.GetRequiredService<DogService>();

                    var countries = await countryService.Get();
                    var response = JsonSerializer.Serialize(countries);

                    await context.Response.WriteAsync(response);
                });
            });
        }
    }
}
