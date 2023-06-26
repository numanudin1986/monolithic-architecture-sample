using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgentApp.DataAccess.Entity;
using AgentApp.BusinessOperation.Interfaces;
using AgentApp.BusinessOperation.Operations;
using AgentApp.DataAccess.Interfaces;
using AgentApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AgentApp.Common;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AgentApp.Helper;
using Microsoft.AspNetCore.Http;

namespace AgentApp
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
            services.AddControllersWithViews();
            services.AddSession();
            services.AddMvc();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDbContext<AgentAppContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AgentAppDatabase"), sqloptions =>
                    {
                        sqloptions.MigrationsAssembly("AgentApp.DataAccess");
                    })
                );


            //#region "JWT Token For Authentication"    
            //SiteKeys.Configure(Configuration.GetSection("AppSettings"));
            //var key = Encoding.ASCII.GetBytes(SiteKeys.Token);

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromMinutes(60);
            //});
            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            // .AddJwtBearer(token =>
            // {
            //     token.RequireHttpsMetadata = false;
            //     token.SaveToken = true;
            //     token.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(key),
            //         ValidateIssuer = true,
            //         ValidIssuer = SiteKeys.WebSiteDomain,
            //         ValidateAudience = true,
            //         ValidAudience = SiteKeys.WebSiteDomain,
            //         RequireExpirationTime = true,
            //         ValidateLifetime = true,
            //         ClockSkew = TimeSpan.Zero
            //     };
            // });

            //#endregion

            InjectAppServices(services);

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InjectAppServices(IServiceCollection services)
        {
            // services.AddScoped<IGenericRepository<AgentRecord>>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBOAgent, BOAgent>();
            services.AddScoped<IBOUser, BOUser>();
            services.AddScoped<IBOStudent, BOStudent>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISessionManager, SessionManager>();
        }
    }
}
