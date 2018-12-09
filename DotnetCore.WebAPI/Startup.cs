using DotnetCore.Core.ApplicationServices.InstitutionServce;
using DotnetCore.Core.ApplicationServices.ServiceUser;
using DotnetCore.Core.DomainServices;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Infrastructure;
using DotnetCore.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetCore.WebAPI
{
    public class Startup
    {
        #region Members
        public IConfiguration Configuration { get; }
        #endregion

        #region Start Up
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Configure Services
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Identity Service
            services.AddDbContext<ApplicationIdentityDbContext>(c =>
               c.UseSqlServer(Configuration.GetConnectionString("default")));

            var builder = services.AddIdentityCore<AppUsers>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(AppRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();

            #endregion


            #region Dependency Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstituteService, InstituteService>();

            // Identity Only
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region MVC
            services.AddMvc();
            #endregion
        }
        #endregion

        #region Configure
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        #endregion

    }
}
