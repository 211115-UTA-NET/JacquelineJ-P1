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
            StringBuilder stringbuilderObject = new StringBuilder();
            string path = "C:\\Users\\ashwi\\OneDrive\\Desktop\\.NET\\PROJECT0\\DBproperties.txt";
            StreamReader reader = new StreamReader(path);
            stringbuilderObject.Append("Data Source=2111-sql-jack.database.windows.net;Initial Catalog=jackie_Project0DB;Persist Security Info=False;User ID=");
            stringbuilderObject.Append(reader.ReadLine());
            stringbuilderObject.Append("; Password =");
            stringbuilderObject.Append(reader.ReadLine());
            reader.Close();
            string connectStr = stringbuilderObject.ToString();

            services.AddDbContext<StoreContext>(
                options => options.UseSqlServer(connectStr));
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<CustomMiddleware1>();


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
