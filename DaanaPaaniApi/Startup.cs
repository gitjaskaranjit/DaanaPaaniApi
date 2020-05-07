using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DaanaPaaniApi.Repository;
using DaanaPaaniApi.infrastructure;

namespace DaanaPaaniApi
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
            services.AddMvc(options => options.Filters.Add<JsonExceptionFilter>()); ;

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(new ApiError(context.ModelState));
                    return result;
                }
               );
            services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            //
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPackageService, PackageService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
