using DuckDuck.Client;
using DuckDuck.ViewModels;
using DuckDuckGoProxy.Application.Managers;
using DuckDuckGoProxy.Application.Persistence;
using DuckDuckGoProxy.Configuration;
using DuckDuckGoProxy.Integration.Interfaces;
using DuckDuckGoProxy.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuckDuckGoProxy
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
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton<IDuckDuckGoManager, DuckDuckGoManager>();
            services.AddSingleton<IHistoryRepository, HistoryRepository>();
            services.AddSingleton<IDuckDuckClient<DuckDuckRequest, DuckDuckResponse>, DuckDuckClient>();
            services.AddSingleton(ctx =>
            {
                return new AppSettings
                {
                    DefaultPageSize = 10,
                    Source = new DuckDuckSource
                    {
                        Key = "DuckDuck",
                        Url = "https://duckduckgo.com/"
                    }
                };
            });
            services.AddSingleton(ctx =>
            {
                var appSettings = ctx.GetService<AppSettings>();
                return appSettings.Source;
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DuckDuckGoProxy", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DuckDuckGoProxy v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
