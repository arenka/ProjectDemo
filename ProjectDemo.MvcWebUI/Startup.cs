using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDemo.Business.Abstract;
using ProjectDemo.Business.Concrete;
using ProjectDemo.DataAccess.Abstract;
using ProjectDemo.DataAccess.Concrete.EntityFramework;
using ProjectDemo.MvcWebUI.Entities;
using ProjectDemo.MvcWebUI.Middlewares;
using ProjectDemo.MvcWebUI.Services;

namespace ProjectDemo.MvcWebUI
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>
                (options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ProjectDemoDb;Trusted_Connection= true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentiyRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc();
        }

       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();
            app.UseNodeModules(env.ContentRootPath);
            app.UseAuthentication();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
        }

        
    }
}
