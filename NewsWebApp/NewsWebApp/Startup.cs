using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.Data;
using NewsWebApp.Models;

namespace NewsWebApp
{
    public class Startup
    {

        private readonly IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddMvc();

            services.AddDbContext<NewsDbContext>(option =>
            {
                option.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });



            services.AddIdentity<User, IdentityRole>()
                                        .AddDefaultTokenProviders()
                                            .AddEntityFrameworkStores<NewsDbContext>();


            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Admin/Account/Login";
            });


            services.AddAuthentication();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseAuthentication();
            app.UseStaticFiles();


            app.UseMvc(route =>
            {

                route.MapRoute(
                    name: "Admin",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

                route.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });


        }
    }
}
