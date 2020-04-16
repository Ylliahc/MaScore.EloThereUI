using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Data;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddLogging();
            services.AddAutoMapper(typeof(Startup), typeof(MaScore.EloThereUI.Infrastructure.Entities.EntityBase));

            services.AddSingleton<WeatherForecastService>();

            services.Configure<MaScore.EloThereUI.Infrastructure.Configurations.MaScoreClientConfiguration>(Configuration.GetSection("MaScoreApi"));

            services.AddHttpClient<MaScore.EloThereUI.Infrastructure.Clients.MaScoreApiClient>();

            services.AddTransient<MaScore.EloThereUI.Domain.Repositories.IGameTypeRepository,
                                    MaScore.EloThereUI.Infrastructure.Repositories.GameTypeRepository>();
            services.AddTransient<MaScore.EloThereUI.Application.Services.GameTypeService>();

            services.AddTransient<MaScore.EloThereUI.Domain.Repositories.IPlayerRepository,
                                    MaScore.EloThereUI.Infrastructure.Repositories.PlayerRepository>();
            services.AddTransient<MaScore.EloThereUI.Application.Services.PlayerService>();

            services.AddTransient<MaScore.EloThereUI.Domain.Repositories.IScoreRepository,
                                    MaScore.EloThereUI.Infrastructure.Repositories.ScoreRepository>();

            services.AddTransient<MaScore.EloThereUI.Application.Services.StatisticsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
