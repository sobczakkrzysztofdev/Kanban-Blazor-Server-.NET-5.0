using Kanban.Areas.Identity;
using Kanban.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLibrary;
using DataAccessLibrary.Other;
using Blazored.Localisation;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Kanban
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
            //added for multilanguage: https://www.youtube.com/watch?v=h82U0RQ9jtQ&t=4298s
            services.AddControllers();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => 
                    options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

            //added
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<IDataAccess, DataAccess>();
            services.AddTransient<ISqlTableDependencyService, SqlTableDependencyService>();
            services.AddScoped<TimeZoneService>();
            services.AddSignalR(e =>
            {
                e.MaximumReceiveMessageSize = 102400000;
            });

            //datetime function - must be
            services.AddBlazoredLocalisation();

            //Debuging
            services.AddServerSideBlazor(o => o.DetailedErrors = true);
        }

        //added for multilanguage: https://www.youtube.com/watch?v=h82U0RQ9jtQ&t=4298s
        private RequestLocalizationOptions GetLocalizationOptons()
        {
            var cultures = Configuration.GetSection("Cultures").GetChildren().ToDictionary(x => x.Key, x => x.Value);
            var supportedCultures = cultures.Keys.ToArray();
            var localizationOptions = new RequestLocalizationOptions().AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            return localizationOptions;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Files")),
                RequestPath = "/Files"
            });

            app.UseRequestLocalization(GetLocalizationOptons());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
