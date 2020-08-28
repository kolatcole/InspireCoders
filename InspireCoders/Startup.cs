using System.Collections.Generic;
using System.Text;
using CorporateArena.Presentation;
using InspireCoders.Domain;
using InspireCoders.Infrastructure;
using InspireCoders.Presentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            services.AddControllers().AddNewtonsoftJson(opt=> {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Test Api",
                    Version = "v1"
                });

                //First we define the security scheme
                opt.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement{
                     {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });

            });

            var tokenSetting = new TokensSettings();
            var tokenConfig = Configuration.GetSection(nameof(TokensSettings));

            services.Configure<TokensSettings>(tokenConfig);

            var tokenSettObj = tokenConfig.Get<TokensSettings>();








            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {

                opt.ClaimsIssuer = tokenSettObj.Issuer;
                opt.Audience = tokenSettObj.Audience;

                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenSettObj.Key)),
                    RequireExpirationTime = true

                };

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
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<IRepo<StudentForum>, StudentForumRepo>();
            services.AddScoped<IAccountRepo, AccountRepo>();


            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IForumService, ForumService>();
            services.AddTransient<IAccountService, AccountService>();
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

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();

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
