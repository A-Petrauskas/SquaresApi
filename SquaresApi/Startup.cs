using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Models;
using Services;

namespace SquaresApi
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
            services.AddControllers();

            services.AddSwaggerGen();

            services.Configure<SquaresDatabaseSettings>(
        Configuration.GetSection(nameof(SquaresDatabaseSettings)));

            services.AddSingleton<ISquaresDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<SquaresDatabaseSettings>>().Value);

            services.AddSingleton<SquaresRepository>();
            services.AddSingleton<SquaresService>();
            services.AddSingleton<ModelEntityConverter>();
            services.AddSingleton<PointStringService>();
            services.AddSingleton<SquareFindService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
