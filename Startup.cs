using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cd_c_passcodeGenerator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            // ALSO ADD THIS LINE FOR SESSION -->
            services.AddSession();
            // ADD THIS LINE --> THIS LINE NEEDS TO BE LAST...
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            // ADD THIS LINE FOR SESSION -->
            app.UseSession();
            // ADD THIS  LINE TO REPLACE app.UseRouting() and app.UseEndpoints --> ALSO THIS NEEDS TO BE ADDED LAST...
            app.UseMvc();
            // app.UseRouting();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });
        }

        // ADD THESE LINES, ALSO - what are they for? WHO KNOWS?! WHAT IS ANYTHING FOR??? Actually, maybe I get these two...? NOT NECESSARY BUT HELPFUL??
        public Startup(IWebHostEnvironment env)
        {
            System.Console.WriteLine(env.ContentRootPath);
            System.Console.WriteLine(env.IsDevelopment());
        }
    }
}
