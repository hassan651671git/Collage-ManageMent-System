using Collage_ManageMent_System.Business;
using Collage_ManageMent_System.Domain;
using Collage_ManageMent_System.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collage_ManageMent_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
       Configuration = configuration;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CollageContext>(options => options.UseSqlServer(
                Configuration["Data:DataBase:ConnectionString"]));

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IStudentBusiness, StudentBusiness>();
            services.AddTransient<IStudentCourseBusiness, StudentCourseBusiness>();
            services.AddTransient<ICourseBusiness, CourseBusiness>();
            services.AddTransient<ITeacherBusiness, TeacherBusinesss>();
            services.AddTransient<IStudentRegisterBusiness, StudentRegisterBusiness>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=students}/{action=index}/{id?}");
            });
            app.UseStaticFiles();
        }
    }
}
