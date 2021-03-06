using AutoMapper;
using DaanaPaaniApi.Helper;
using DaanaPaaniApi.infrastructure;
using DaanaPaaniApi.Model;
using DaanaPaaniApi.Repository;
using DaanaPaaniApi.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Okta.AspNetCore;
using System;
using System.Linq;

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
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.Configure<HereApiOptions>(Configuration.GetSection("HereApiOptions"));
            services.AddMvc(options =>
            {
                options.Filters.Add<JsonExceptionFilter>();
                //var policy = new AuthorizationPolicyBuilder()
                //.RequireAuthenticatedUser()
                //.Build();
                //options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    // options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(new ApiError(context.ModelState));
                    return result;
                }
               );
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                                                                            x => x.UseNetTopologySuite()));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin()
                                                               .AllowAnyMethod()
                                                               .AllowAnyHeader()
                                                               );
            });
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICalculator, DefaultCalculator>();
            services.AddScoped<IGeocodeService, HereGeocodeService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            }).AddOktaWebApi(new OktaWebApiOptions()
            {
                OktaDomain = Configuration.GetSection("Okta").GetSection("OktaDomain").Value
            });
            services.AddAuthorization();
            services.AddSwaggerDocument(document =>
            {
                document.AddSecurity("Bearer", Enumerable.Empty<string>(), new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.OAuth2,
                    Flow = NSwag.OpenApiOAuth2Flow.Implicit,
                    AuthorizationUrl = "https://dev-333876.okta.com/oauth2/default/v1/authorize"
                });
                document.PostProcess = setting =>
                {
                    setting.Info.Version = "v1";
                    setting.Info.Title = "Daana Paani API";
                    setting.Info.Description = "ASP.NET core web api for tiifin service management";
                    setting.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Jaskaranjit singh",
                        Email = "jaskaran.sd@live.ca",
                        Url = "http://jaskaranjitsingh.com"
                    };
                };
            }

            );
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
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3(setting =>
            {
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