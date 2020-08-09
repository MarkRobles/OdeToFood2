using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood2.Data;

namespace OdeToFood2
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
          

            //Configure EntityFramework Core to use SQL and my connectionstring
            services.AddDbContextPool<OdeToFoodDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"))
            ); 

            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();  
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddRazorPages();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //This is the pipeline of the middleware and it is in bidirectional order of execution
            //maybe when some request in , the first module of middleware does not do nothig to process that in. But it procees it like a out

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.Use(SayHelloMiddleware);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
         


            app.UseRouting();

            app.UseAuthorization();

          
            app.UseEndpoints(e =>
            {
                e.MapRazorPages();
                e.MapControllers();
            });



        }

        private RequestDelegate SayHelloMiddleware(RequestDelegate arg)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hello"))
                {
                    await ctx.Response.WriteAsync("Hello, World!");
                }
                //else {
                //    await next(ctx);
                //}
            
            };
        }
    }
}
