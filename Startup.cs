using System.Xml.Schema;
using System.Net.Mime;
using System;
using System.ComponentModel.Design;
using System.Net.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tp.Database;

namespace tp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

       //  This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
         {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                opciones =>
                {
                    opciones.LoginPath = "/Usuario/Ingresar";
                    opciones.AccessDeniedPath = "/Usuario/AccesoDenegado";
                    opciones.LogoutPath = "/Usuario/Salir";
                }

            );

            services.AddControllersWithViews();
            services.AddDbContext<JuegoDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
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
                app.UseExceptionHandler("/Juego/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Juego}/{action=GetAll}/{id?}");
            });

            app.UseCookiePolicy();
        }
    }
}
