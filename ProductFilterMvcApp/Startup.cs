using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductFilterMvcApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method is used to configure services for dependency injection
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Add MVC services
        }

        // This method is used to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Developer error page
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Redirect to Error action
                app.UseHsts();  // HTTP Strict Transport Security
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();  // Serve static files like CSS, JS

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
