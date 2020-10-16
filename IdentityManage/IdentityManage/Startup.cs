using IdentityManager.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IdentityManager
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, MailJetEmailSender>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 0;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 2;
                // opt.User.AllowedUserNameCharacters = true;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;

            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Accessdenied");
            });
            ExternalLogin(services);

            services.AddControllersWithViews();
        }

        #region Método responsável por [CRIAR AS CONFIGURAÇÕES DOS LOGINS EXTERNOS]
        private void ExternalLogin(IServiceCollection services)
        {
            //Configurando para acessar o login através do Facebook
            services.AddAuthentication().AddFacebook(opt =>
            {
                //As informações de Acesso é configurado através da página do facebook developer.
                opt.AppId = Configuration["ExternalLogin:Facebook:AppId"];
                opt.AppSecret = Configuration["ExternalLogin:Facebook:AppSecret"];
            });


            //Configurando para acessar o login através do Google
            services.AddAuthentication().AddGoogle(opt =>
            {
                //As informações de Acesso é configurado através da página do Google developer.
                opt.ClientId = Configuration["ExternalLogin:Google:ClientId"];
                opt.ClientSecret = Configuration["ExternalLogin:Google:ClientSecret"];
            });

            //Configurando para acessar o login através do Microsoft
            services.AddAuthentication().AddMicrosoftAccount(opt =>
            {
                //As informações de Acesso é configurado através da página do Microsoft developer.
                opt.ClientId = Configuration["ExternalLogin:Microsoft:ClientId"];
                opt.ClientSecret = Configuration["ExternalLogin:Microsoft:ClientSecret"];
            });
        }
        #endregion
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
