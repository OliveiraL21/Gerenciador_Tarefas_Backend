using CrossCutting.DependencyInjection;
using CrossCutting.EnviromentConfiguration;
using Domain.Entidades;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UserApplication.Context;

namespace UserApplication
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

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            EnviromentConfigurations.ConfigureDevelopmentEnvironment(services, Configuration);

            services.AddControllers();
            services.AddTransient<UserDbContext>().AddDbContext<UserDbContext>(options => options.UseMySql(Configuration.GetConnectionString("UserConnection"), new MySqlServerVersion(new Version(8, 0, 38)),
                mySqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }
                ));

            services.AddIdentity<CustomIdentityUser, IdentityRole<Guid>>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = true;
                opt.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            ConfigureService.ConfigureServicesUserAplication(services);

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UserApplication",
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
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/users/swagger/v1/swagger.json", "UserApplication v1"));
                }
                else if (env.IsDevelopment())
                {
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserApplication v1"));
                }

            }

            app.UseCors(MyAllowSpecificOrigins);


            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseDeveloperExceptionPage();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
