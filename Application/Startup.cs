using Data;
using Data.Context;
using Domain.Repository;
using Domain.Services.Clientes;
using Domain.Services.Projetos;
using Domain.Services.Tarefas;
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
using Services.Clientes;
using Services.Projetos;
using Services.StatusService;
using Services.Tarefas;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Controle_TarefasDB")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
       
            #region Services
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProjetoService, ProjetoService>();
            services.AddTransient<StatusService, StatusService>();
            services.AddTransient<ITarefaService, TarefaService>();
            #endregion

            #region Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
          
            #endregion


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application v1"));
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
