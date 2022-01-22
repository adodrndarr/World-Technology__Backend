using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NLog;
using Services;
using Services.HelperService.Helpers;
using System.IO;
using Worldtech.Extensions;


namespace Worldtech
{
    public class Startup
    {
        string nlogConfigFilePath = string.Concat(Directory.GetCurrentDirectory(), "/nlog.config");

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(nlogConfigFilePath);
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });            

            DependencyInjectionModule.RegisterRepositories(services);
            DependencyInjectionModule.RegisterServices(services);
            DependencyInjectionModule.RegisterContexts(services, Configuration);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerManager logger, WorldtechDbContext worldtechDbContext)
        {
            if (env.IsDevelopment())
            {
                worldtechDbContext.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
            }           
            else app.UseHsts();

            app.ConfigureExceptionHandler(logger);
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Worldtech",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
