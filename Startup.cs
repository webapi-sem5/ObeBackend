using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ObeSystem.Application.Modules;
using ObeSystem.Application.Assessments;


using ObeSystem.Repository;
using ObeSystem.Models;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using ObeSystem.Middleware;
using ObeSystem.Interfaces;
using ObeSystem.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ObeSystem
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
           

            
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OBEConnection")));

            services.AddControllers();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

          



            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddMediatR(typeof(Application.Modules.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Assessments.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Assessments.Edit.Handler).Assembly);
            services.AddMediatR(typeof(Application.Lolists.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Polists.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Students.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Thresholds.List.Handler).Assembly);
            services.AddMediatR(typeof(Application.Grades.List.Handler).Assembly);

            services.AddControllers(opt =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            }
            )
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Application.Assessments.Create>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddAutoMapper(typeof(Application.Assessments.List.Handler));

            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<AppDbContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });

            services.AddScoped<IJwtGenerator,JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();

            }

            //app.UseHttpsRedirection(); Just comment for development

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
