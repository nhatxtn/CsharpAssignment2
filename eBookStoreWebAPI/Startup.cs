using BusinessObject;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBookStoreWebAPI
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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultSQLConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); // Register IRepository<T> for all types T
            services.AddScoped<IRepository<Book>, Repository<Book>>(); // Register IRepository<Book>
            services.AddScoped<IRepository<Author>, Repository<Author>>(); // Register IRepository<Author>
            services.AddScoped<IRepository<Publisher>, Repository<Publisher>>(); // Register IRepository<Publisher>
            services.AddScoped<IRepository<Role>, Repository<Role>>(); // Register IRepository<Role>
            services.AddScoped<IRepository<User>, Repository<User>>(); // Register IRepository<User>

            services.AddScoped<BookService>(); // Register BookService
            services.AddScoped<AuthorService>(); // Register AuthorService
            services.AddScoped<PublisherService>(); // Register PublisherService
            services.AddScoped<RoleService>(); // Register RoleService
            services.AddScoped<UserService>(); // Register UserService
            services.AddHttpContextAccessor(); // Add HttpContextAccessor
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllers().AddOData(option => option.Select().Filter().OrderBy());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eBookStoreWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eBookStoreWebAPI v1"));
            }
            app.UseSession();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
