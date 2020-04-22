using AutoMapper;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Services;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
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

		private IApiVersionDescriptionProvider _apiVersionProvider;


		public void ConfigureServices(IServiceCollection services)
		{
			// 注册配置选项的服务,  构造器或中间件就可以通过注入的方式获取配置。
			services.Configure<AppSetting>(Configuration);
			AppSettingHelper.InitSetting(Configuration.GetSection("EMISSetting"));

			// API 版本控制
			services.AddApiVersioning(options =>
			{
				options.ReportApiVersions = false;
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
			}).AddVersionedApiExplorer(option => { 
				option.GroupNameFormat = "'v'VVV";
				option.AssumeDefaultVersionWhenUnspecified = true;
			});

			// 配置接口文档生成
			_apiVersionProvider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
			services.AddSwaggerGen(c =>
			{
				foreach (var description in _apiVersionProvider.ApiVersionDescriptions)
				{
					c.SwaggerDoc(description.GroupName, new OpenApiInfo
					{
						Title = $"初心教育接口文档 v{description.ApiVersion}",
						Version = description.ApiVersion.ToString(),
						Description = "切换版本请点右上角版本切换"
					});
				}
				//var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
				//var xmlPath = Path.Combine(basePath, "ChuXin.EMIS.WebAPI.xml");
				c.IncludeXmlComments(this.GetType().Assembly.Location.Replace(".dll", ".xml"), true);
			});
			// 兼容NewtonsoftJsonAddSwaggerGen
			services.AddSwaggerGenNewtonsoftSupport();

			// 注入数据库连接
			string conn = Configuration["ConnectionString:DefaultConnectionString"];
			services.AddDbContext<EFDbContext>(options => options.UseMySql(conn));
			TableCodeHelper.ServiceProvider = services.BuildServiceProvider();

			// 注册AutoMapper
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// 业务服务注册
			services.AddTransient<IAdoRepository, AdoRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IStudentPotentialRepository, StudentPotentialRepository>();

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
					foreach (var descript in _apiVersionProvider.ApiVersionDescriptions)
					{
						c.SwaggerEndpoint($"/swagger/{descript.GroupName}/swagger.json", descript.GroupName.ToUpperInvariant());
					}
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
