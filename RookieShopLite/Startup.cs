using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RookieShopLite.Areas.Admin.ApiServices.Brand;
using RookieShopLite.Areas.Admin.ApiServices.Cart;
using RookieShopLite.Areas.Admin.ApiServices.CartProduct;
using RookieShopLite.Areas.Admin.ApiServices.Category;
using RookieShopLite.Areas.Admin.ApiServices.Product;
using RookieShopLite.Areas.Admin.ApiServices.Rating;
using RookieShopLite.Areas.Admin.ApiServices.User;
using RookieShopLite.Data;
using System;
using System.Net;
using System.Net.Http;

namespace RookieShopLite
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddDistributedMemoryCache();
            services.AddSession(cfg =>
            {
                cfg.Cookie.HttpOnly = true;
                cfg.Cookie.IsEssential = true;
                cfg.IdleTimeout = new TimeSpan(0, 30, 0);
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RookieShop", Version = "v1" });
            });

            services.AddHttpContextAccessor();
            services.AddHttpClient("local", (configureClient) =>
            {
                configureClient.BaseAddress = new Uri(Configuration.GetValue<string>("Uri:LocalUri"));
            })
                .ConfigurePrimaryHttpMessageHandler((serviceProvider) =>
                {
                    var httpContext = serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
                    var cookieContainer = new CookieContainer();
                    if (httpContext.Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
                    {
                        var identityCookieValue = httpContext.Request.Cookies[".AspNetCore.Identity.Application"];
                        cookieContainer.Add(new Uri(Configuration.GetValue<string>("Uri:LocalUri")), new Cookie(".AspNetCore.Identity.Application", identityCookieValue));
                    }
                    return new HttpClientHandler()
                    {
                        CookieContainer = cookieContainer
                    };
                });

            services.AddTransient<IBrandApiService, BrandApiService>();
            services.AddTransient<ICategoryApiService, CategoryApiService>();
            services.AddTransient<IProductApiService, ProductApiService>();
            services.AddTransient<ICartApiService, CartApiService>();
            services.AddTransient<ICartProductApiService, CartProductApiService>();
            services.AddTransient<IRatingApiService, RatingApiService>();
            services.AddTransient<IUserApiService, UserApiService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseSwagger();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RookieShop v1"));

            app.UseCors("AllowAnyOrigin");
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
