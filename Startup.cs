using ECommerce.Data;
using ECommerce.Entities.Identity;
using ECommerce.Workers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            //appsettings.json doyas�n� okumak i�in kulan�yoruz.
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllersWithViews(opt => opt.EnableEndpointRouting = false)
                .AddRazorRuntimeCompilation();

            services
                .AddRazorPages();

            services
                .AddDbContext<IdentityContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Identity")));

            services
                .AddIdentity<ShopUser, ShopRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services
                .AddTransient<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Statik olan dosyalar�n bulunaca�� klas�r� aktifle�tirir.
            app.UseStaticFiles();

            //Kimlik do�rulama yap�s�: Kullan�c� yap�s�n� denetler
            app.UseAuthentication();

            //Yetkilendirme yap�s�: Eri�imleri denetler
            app.UseAuthorization();

            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "HomeAbout",
                    template: "about",
                    defaults: new { controller = "Home", action = "About" }
                    );
                route.MapRoute(
                    name: "HomeContact",
                    template: "contact",
                    defaults: new { controller = "Home", action = "Contact" }
                    );
                route.MapRoute(
                    name: "Default",
                    template: "{Controller=Home}/{Action=Index}/{id?}"
                    );
            });
        }
    }
}
