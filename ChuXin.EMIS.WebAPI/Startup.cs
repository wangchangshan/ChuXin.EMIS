using AutoMapper;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Services;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChuXin.EMIS.WebAPI
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
            // 注册配置选项的服务,  构造器或中间件就可以通过注入的方式获取配置。
            services.Configure<AppSetting>(Configuration);

            // 注入数据库连接
            string conn = Configuration["ConnectionString:DefaultConnectionString"];
            services.AddDbContext<EFDbContext>(options => options.UseMySql(conn));

            // 注册AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // 业务服务注册
            services.AddTransient<IAdoRepository, AdoRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
