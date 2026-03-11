using AutoMapper;
using CrossCutting.DependencyInjection;
using CrossCutting.Mapping;
using Data.Context;
using Data.Repository;
using Data.Seeds;
using Domain.Repository;
using Domain.Services.Clientes;
using Domain.Services.Dashboard;
using Domain.Services.Projetos;
using Domain.Services.Tarefas;
using FastReport.Data;
using FastReport.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Clientes;
using Services.DashBoard;
using Services.Projetos;
using Services.StatusService;
using Services.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddControllers();

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            //FastReport.Utils.RegisteredObjects.AddConnection(typeof(MySqlDataConnection));
            services.AddFastReport();
            RegisteredObjects.AddConnection(typeof(MySqlDataConnection));
            //importar o MySqlDataConnection da lib FastReport.Data

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin();
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();

                                  });
            });

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn"));

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Application",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Lucas",
                        Email = "lucasoliveira508@gmail.com",

                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Adicione o token jwt",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference(){
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, new List<string>()
                    }
                });
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("pt-BR");
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    return Task.FromResult(new ProviderCultureResult("pt-BR"));
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) && env.IsProduction())
                {
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/application/swagger/v1/swagger.json", "Application v1"));
                }
                else
                {
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1"));
                }

            }


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseFastReport();
            app.UseStaticFiles();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MyContext>();

                // Aplica migrations
                context.Database.Migrate();

                // Roda seed condicional
                DbInitializer.Seed(context);
            }
        }
    }
}
