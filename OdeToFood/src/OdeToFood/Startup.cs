using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(env.ContentRootPath)
                              .AddJsonFile("appsettings.json")
                              .AddEnvironmentVariables();

           Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Oops!")
                });
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.UseFileServer(); // delete index.html when going to MVC or it will always be displayed

            //Pre-MVC, demo how middleware works
            //app.UseWelcomePage("/welcome");

            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Something went wrong!");
            //    var message = greeter.GetGreeting();
            //    await context.Response.WriteAsync(message);
            //});

            //app.UseMvcWithDefaultRoute(); // adds middleware to direct a request to default mvc controller method i.e. HomeController with an Index method
            app.UseMvc(ConfigureRoutes); //use MVC without default routing

            app.Run(ctx => ctx.Response.WriteAsync("Not Found")); // if MVC routing is not working or route is not specified
        }

        //convention based routing
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
