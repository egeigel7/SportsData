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
using Microsoft.OpenApi.Models;
using SportsData.Application.Extensions;
using SportsData.Infrastructure.Extensions;

namespace SportsDataApp.Api
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
            services.AddMvcCore()
                .AddApiExplorer();
            services.AddSwaggerGen(swagger => { swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Sports API" }); });

            services.AddHttpClient();

            services.AddSportsDataApplicationLayer();
            services.AddSportsDataInfrastructureLayer(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sports API"); });

            app.UseRouting();
            app.UseCors("AllowAnyCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapHealthChecks("/health");
                endpoints.MapControllers();
            });
        }
    }
}
