using Data.Context;
using Domain.Services.Email;
using Domain.Services.Login;
using Domain.Services.ResetaSenha;
using Domain.Services.Usuarios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Services.Email;
using Services.Login;
using Services.ResetSenha;
using Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            services.AddControllers();
            services.AddTransient<UserDbContext>().AddDbContext<UserDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
           
            services.AddIdentity<IdentityUser<int>, IdentityRole<int>>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ILogoutService, LogoutService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IResetaSenha, ResetaSenhaService>();

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserApplication", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserApplication v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);
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
