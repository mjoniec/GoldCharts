using CurrencyDataProvider;
using CurrencyDataProvider.Repositories;
using GoldChartsApi.Services;
using MetalsDataProvider.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoldChartsApi
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
            services.AddDbContext<CurrencyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();
            
            services.AddScoped<CombineCurrencyAndMetalDataService>();
            
            //services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<ICurrenciesRepository, FallbackCurrenciesRepository>();

            services.AddScoped<IMetalsPricesProvider, GuandlMetalsPricesProvider>();
            //services.AddScoped<IMetalsPricesProvider, FallbackMetalsPricesProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
