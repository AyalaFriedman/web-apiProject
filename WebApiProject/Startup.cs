

using AutoMapper.Configuration;
using BL;
using DL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

namespace WebApiProject
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
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IuserDl, userDl>();
            services.AddScoped<IuserBL, userBL>();

            services.AddScoped<IProductBL, ProductBL>();
            services.AddScoped<IProductDL, ProductDL>();

            services.AddScoped<IcategoriesDL, categoriesDL>();
            services.AddScoped<ICategoriesBL, CategoriesBL>();

            services.AddScoped<IOrederBL, OrederBL>();
            services.AddScoped<IOrderDL, OrderDL>();

            services.AddControllers();
          
            services.AddDbContext<Production_aaContext>(options => options.UseSqlServer(
                           Configuration.GetConnectionString("mby")), ServiceLifetime.Scoped);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiProject", Version = "v1" });
            });
          
           services.AddResponseCaching();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseErrorHandlingMiddleware();
            if (env.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiProject v1"));
            }
            logger.LogInformation("we love u");
            app.UseResponseCaching();
            app.Use(async (context, next) =>
            {
                    context.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromSeconds(10)
                    };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                    new string[] { "Accept-Encoding" };

                await next();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.Map("/api", app2 =>
            {
                app2.UseRouting();
                app2.UseRATINGMiddleware();
                app2.UseAuthorization();
                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
