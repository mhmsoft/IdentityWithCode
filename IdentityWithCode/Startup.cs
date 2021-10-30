using IdentityWithCode.Models.context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityWithCode
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
            //contextin connection stringi veriliyor.
            services.AddDbContext<Ap1DbContext>(x=> {
                                 x.UseSqlServer(Configuration.GetConnectionString("IdentityDB"));
                            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<Ap1DbContext>();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
            services.ConfigureApplicationCookie(_ =>
            {
                _.LoginPath = new PathString("/Account/Login");
                _.LogoutPath = new PathString("/Account/SignOut");
                _.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityExampleCookie", //Oluþturulacak Cookie'yi isimlendiriyoruz.
                    HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
                    //Expiration = TimeSpan.FromMinutes(2), //Oluþturulacak Cookie'nin vadesini belirliyoruz.
                    SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
                    SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
                };
                _.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
                _.ExpireTimeSpan = TimeSpan.FromMinutes(10); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
                _.AccessDeniedPath = new PathString("/Account/AccessDenied");
            });
            /*
            services.Configure<CookieAuthenticationOptions>(options =>
            {
                options.LoginPath = new PathString("/Login");
                options.AccessDeniedPath = new PathString("/AccessDenied");
                options.LogoutPath = new PathString("/SignOut");
            });
            */
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            Task.Run(() => this.CreateRoles(roleManager)).Wait();
        }
        private async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (string rol in this.Configuration.GetSection("Roles").Get<List<string>>())
            {
                if (!await roleManager.RoleExistsAsync(rol))
                {
                    await roleManager.CreateAsync(new IdentityRole(rol));
                }
            }
        }
    }
}
