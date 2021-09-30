using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WeatherForecast.BLL.Services;
using WeatherForecast.Domain.Interfaces;
using WeatherForecast.Integrations.OneCallApi.Interfaces;
using WeatherForecast.Integrations.OneCallApi.Services;

namespace WeatherForecast.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddJsonFormatters().AddApiExplorer();

            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Forecast API", Version = "v1" });
            });

            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IOneCallApiService, OneCallApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Forecast API V1");
            });

            app.UseMvc();
        }
    }
}
