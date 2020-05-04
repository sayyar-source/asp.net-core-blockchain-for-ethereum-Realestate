using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using RealEstate.DataLayer;
using RealEstate.DataLayer.Context;
using RealEstate.Domain.Dto;
using RealEstate.Domain.User;
using RealEstate.Services.Repositories;
using RealEstate.Services.Services;

namespace RealEstate.UI
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
           
            // services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(MappingEntity).GetTypeInfo().Assembly);
            //services.AddAutoMapper(typeof(RealEstateService).GetTypeInfo().Assembly);
            services.AddTransient<IRealEstateService, RealEstateService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEstateContractRepository, EstateContractRepository>();
            services.AddTransient<IEstateRepository, EstateRepository>();
            services.AddTransient<IRequestEstateRepository, RequestEstateService>();
            services.AddDbContext<RealEstateDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      
            services.AddControllers();
         
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RealEstateDbContext>()
                .AddDefaultTokenProviders();
            //jwt start
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            services.AddAuthentication(options=> {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options => {
                    options.AccessDeniedPath = new PathString("/Account/Login/");
                    options.LoginPath = new PathString("/Account/Login/");
                    options.LogoutPath = new PathString("/Account/Logout/");
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                });
            //jwt end

            services.AddMvc();
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
            SeedDB.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
          
            //Add JWToken to all incoming HTTP Request Header
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
