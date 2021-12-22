using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Repositories.Repositories;
using TicTacToe.Repositories.Repositories.Interfaces;
using TicTacToe.Services;
using TicTacToe.Services.Interfaces;

namespace TicTacToe.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IPlayerService, PlayerService>();
        }

            public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(  // Connect to the Postgres database
                    Configuration.GetConnectionString("DefaultConnection"),
                    builder => {
                        //project where we want Code-First Migrations to reside
                        builder.MigrationsAssembly("TicTacToe.Repositories");

                    })
                );
     
            services.AddControllers();

            ConfigureDependencyInjection(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicTacToe API", Version = "v1" });
                var apiPath = Path.Combine(System.AppContext.BaseDirectory, "TicTacToe.Api.xml");
                var modelsPath = Path.Combine(System.AppContext.BaseDirectory, "TicTacToe.Models.xml");
               //c.IncludeXmlComments(apiPath);
               // c.IncludeXmlComments(modelsPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicTacToe.Api v1"));
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
