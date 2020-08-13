using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Presentation;
using InspireCoders.Domain;
using InspireCoders.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InspireCoders
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

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Test Api",
                    Version = "v1"
                });

                

            });

            services.AddDbContext<TContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("InspireCoders.Presentation.Core"));

                
            });

            services.AddScoped<IRepo<Contact>, ContactRepo>();
            services.AddScoped<IRepo<Facilitator>, FacilitatorRepo>();
            services.AddScoped<IRepo<Student>, StudentRepo>();
            services.AddScoped<IRepo<Applicant>, ApplicantRepo>();
            services.AddScoped<IRepo<Forum>, ForumRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //var swaggerOpt = new SwaggerOpt();
            //Configuration.GetSection(nameof(SwaggerOpt)).Bind(swaggerOpt);
            //app.UseSwagger(opt =>
            //{
            //    opt.RouteTemplate = swaggerOpt.JsonRoute;
            //});
            //app.UseSwaggerUI(opt =>
            //{
            //    opt.SwaggerEndpoint(swaggerOpt.UIEndPoint, swaggerOpt.Description);
            //});

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var swaggerOpt = new SwaggerOpt();
            Configuration.GetSection(nameof(SwaggerOpt)).Bind(swaggerOpt);
            app.UseSwagger(opt => {
                opt.RouteTemplate = swaggerOpt.JsonRoute;
            });
            app.UseSwaggerUI(opt => {
                opt.SwaggerEndpoint(swaggerOpt.UIEndPoint, swaggerOpt.Description);
            });

        }
    }
}
