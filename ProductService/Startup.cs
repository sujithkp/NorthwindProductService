using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductService.DAL;

namespace ProductService
{
    public class Startup
    {
        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment CurrentEnvironment { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            CurrentEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDomainController, ProductDomainController>();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{CurrentEnvironment.EnvironmentName}.json")
                .Build();

            var productConfiguration = configuration.GetSection(nameof(ProductDomainConfiguration))
                .Get<ProductDomainConfiguration>();

            services.AddScoped<IProductDomainConfiguration>(serviceprovider => productConfiguration);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}