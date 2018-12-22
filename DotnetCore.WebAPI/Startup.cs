using DotnetCore.Core.ApplicationServices.InstitutionServce;
using DotnetCore.Core.ApplicationServices.ServiceUser;
using DotnetCore.Core.DomainServices;
using DotnetCore.Core.DomainServices.IData;
using DotnetCore.Core.Entity;
using DotnetCore.Core.Utility;
using DotnetCore.Infrastructure;
using DotnetCore.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

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

            services.AddIdentity<AppUsers, AppRole>()
                            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                            .AddDefaultTokenProviders();
            #endregion


            #region Dependency Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstituteService, InstituteService>();
            services.AddTransient<IJwtFactory, JwtFactory>();

            // Identity Only
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region JWT Configuration
            string SecretKey = Configuration.GetValue<string>("JwtIssuerOptions:SecretKey");
            SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = _signingKey,
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });


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
            app.UseExceptionHandler(
              builder =>
              {
                  builder.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                IExceptionHandlerFeature error = context.Features.Get<IExceptionHandlerFeature>();
                                if (error != null)
                                {
                                    // context.Response.AddApplicationError(error.Error.Message);
                                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                }
                            });
              });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        #endregion

    }
}
