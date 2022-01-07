using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;
using Project1WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware1>();

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();

        }

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             /* /*app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run");

            });*/

          /*  app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-1 1 \n");

                await next();

                await context.Response.WriteAsync("Hello from Use-1 2 \n");
            });

            app.UseMiddleware<CustomMiddleware1>();
            //app.Map("/jackie", CustomCode);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-2 1 \n");

                await next();

                await context.Response.WriteAsync("Hello from Use-2 2 \n");
            });
            
             app.Run(async context =>
             {
                 await context.Response.WriteAsync("Hello from Run\n");

             });*/




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }

       /* private void CustomCode(IApplicationBuilder obj)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from method 1 \n");

                await next();

                await context.Response.WriteAsync("Hello from method \n");
            });

        }*/
    }
}
