using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.DependencyInjection;
using Project1WebApp.Data;
using Project1WebApp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Project1WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("Store-DB-Connection");

            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<CustomMiddleware1>();

            services.AddSingleton<IDBRepository>(provider => new DBRepository(connectionString));
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderDetailsRepository, OrderDetailsRepository>();
            services.AddSingleton<IStoreRepository, StoreRepository>();

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
