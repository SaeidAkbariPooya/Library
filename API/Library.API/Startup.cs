using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Context;
using Library.Application.Interfaces;
using Library.Application.Services;
using Microsoft.OpenApi.Models;
using Library.Core.Interfaces;
using Library.Infrastructure.Repository;

namespace Library.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add Swagger services  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddDbContext<LibraryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LibraryDBConnection"));
            });

            RegisterServices(services);
            //services.AddScoped<IBookService, BookService>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // اطمینان حاصل کنید که این خط وجود دارد  
            });
        }

        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IBookRepository, BookRepositry>();
        }
    }
}
