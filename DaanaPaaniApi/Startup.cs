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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DaanaPaaniApi.DTOs;
using Okta.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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
            services.AddMvc(options => {
                options.Filters.Add<JsonExceptionFilter>();
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                
                
                }); 
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(new ApiError(context.ModelState));
                    return result;
                }
               );
            services.AddDbContext<DataContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(options=>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin()
                                                               .AllowAnyMethod()
                                                               .AllowAnyHeader());
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IAddressTypeService, AddressTypeService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;

            }).AddOktaWebApi(new OktaWebApiOptions()
            {
            OktaDomain = Configuration.GetSection("Okta").GetSection("OktaDomain").Value
            });
            services.AddAuthorization();
            services.AddSwaggerDocument(document=>document.AddSecurity("Bearer",Enumerable.Empty<string>(),new NSwag.OpenApiSecurityScheme { 
            
                Type =NSwag.OpenApiSecuritySchemeType.OAuth2,
                 Flow = NSwag.OpenApiOAuth2Flow.Implicit,
                 AuthorizationUrl = "https://dev-333876.okta.com/oauth2/default/v1/authorize",




            }));

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3(setting=> {
                setting.OAuth2Client = new NSwag.AspNetCore.OAuth2ClientSettings
                {
                    
                    ClientId = "0oabm5bk8wDtCKnx14x6",
                    AppName = "My SPA",
                    UsePkceWithAuthorizationCodeGrant = true,
                   AdditionalQueryStringParameters =
                    {
                        {"nonce" , new Random().Next(123456,999999).ToString()},
                        {"response_Type" , "token" },
                        {"scope" , "openid" }
                    }
                    
                };
               
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
