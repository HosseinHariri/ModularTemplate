using ModularTemplate.Application.Customers.Create;
using ModularTemplate.Application.Customers.GetList;
using ModularTemplate.Data.DBContext;
using ModularTemplate.Presentation.Server.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ModularTemplate.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerGen(swagger =>
            {

                swagger.CustomSchemaIds(x => x.FullName);
            });

            var cnn = "Data Source=.;Initial Catalog=ModularTemplate;Integrated Security=True";
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies()
                    .UseSqlServer(cnn, b => b.MigrationsAssembly("ModularTemplate.Presentation.Server"));
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<AppDbContext>();
            services.AddTransient<ICreateCustomerHandler, CreateCustomerHandler>();
            services.AddTransient<IGetCustomersHandler, GetCustomersHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            app.UseWebAssemblyDebugging();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
            });

            //app.UseHttpsRedirection();
            //app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //    endpoints.MapControllers();
            //    endpoints.MapFallbackToFile("index.html");
            //});
        }
    }
}
