using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetsProject.Data;
using PetsProject.HangFireJob.Vet;
using PetsProject.Models;
using PetsProject.Repositories;

namespace PetsProject
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
            services.AddMvc(o => o.EnableEndpointRouting = false).AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("PetsHouse")));
            services.AddTransient<IVetRegistraitonRepo, VetRegistrationRepo>();
            services.AddTransient<IPetRegistrationRepo, PetRegistrationRepo>();
            services.AddTransient<IVacancyRepo, VacancyRepo>();
            services.AddTransient<IDamakebaNoDocumentRepo, DamakebaNoDocumentRepo>();
            services.AddIdentity<AppUser, IdentityRole>(option=>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseMemoryStorage());
            services.AddHangfireServer();
            services.AddTransient<IVetJob, VetJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{Controller=Home}/{Action=Index}/{id?}");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseHangfireDashboard("/EYEt<_1e*dj.jYpO=(");
            recurringJobManager.AddOrUpdate("Run every hour", () => serviceProvider.GetService<IVetJob>().VetCurrnetJob(), Cron.Minutely);

        }
    }
}
