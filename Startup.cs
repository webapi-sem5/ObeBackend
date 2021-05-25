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
using ObeSystem.Helpers;
using ObeSystem.Interfaces;
using ObeSystem.Repository;

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
            //services.AddScoped<ILolistRepository, LolistRepository>();

           // services.AddScoped<IPolistRepository, PolistRepository>();

            //services.AddScoped<IModuleRepository, ModuleRepository>();

            //services.AddScoped<IAssessmentRepository, AssessmentRepository>();


            //services.AddDbContext<AppDbContext>(options => options.UseMySql(Configuration.GetConnectionString("OBEConnection")));
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OBEConnection")));

            services.AddControllers();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddScoped<IUserService, UserService>();



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

            services.AddAutoMapper(typeof(Application.Assessments.List.Handler));



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection(); Just comment for development

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
