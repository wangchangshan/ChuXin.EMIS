using AutoMapper;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Services;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
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
            AppSettingHelper.InitSetting(Configuration.GetSection("EMISSetting"));

            // API 版本控制
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // 配置接口文档生成
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = " 初心教育接口文档", Version = "V1" });
            });
            services.AddSwaggerGenNewtonsoftSupport(); // explicit opt-in - needs to be placed after AddSwaggerGen()

            // 注入数据库连接
            string conn = Configuration["ConnectionString:DefaultConnectionString"];
            services.AddDbContext<EFDbContext>(options => options.UseMySql(conn));

            // 注册AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // 业务服务注册
            services.AddTransient<IAdoRepository, AdoRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddControllers()
            .AddNewtonsoftJson(setup =>
            {
                // 配置Json格式
                setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                setup.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
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
