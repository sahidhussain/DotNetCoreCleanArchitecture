using DotnetCore.Core.ApplicationServices.InstitutionServce;
using DotnetCore.Core.DomainServices;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Infrastructure;
using DotnetCore.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            #endregion

            #region Dependency Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstituteService, InstituteService>();
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
