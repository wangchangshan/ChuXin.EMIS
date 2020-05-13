using ChuXin.EMIS.IDP.DataBaseContext;
using ChuXin.EMIS.IDP.IServices;
using ChuXin.EMIS.IDP.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityServer4.Models;
using System.Reflection;

namespace ChuXin.EMIS.IDP
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			string conn = Configuration["ConnectionString:DefaultConnectionString"];
			services.AddDbContext<EFDbContext>(options => options.UseMySql(conn));

			services.AddScoped<IUserRepository, UserRepository>();

			//var builder = services.AddIdentityServer();
			////���ÿ�������ʱǩ��ƾ��
			//builder.AddDeveloperSigningCredential();
			//builder.AddInMemoryIdentityResources(Config.GetIdentityResources());
			//builder.AddInMemoryApiResources(Config.GetApis());
			//builder.AddInMemoryClients(Config.GetClients());

			var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
			services.AddIdentityServer()
			   .AddDeveloperSigningCredential()
			   .AddTestUsers(Config.GetUsers())
			   // this adds the config data from DB (clients, resources)
			   .AddConfigurationStore(options =>
			   {
				   options.ConfigureDbContext = builder =>
					   builder.UseMySql(conn,
						   sql => sql.MigrationsAssembly(migrationsAssembly));
			   })
			   // this adds the operational data from DB (codes, tokens, consents)
			   .AddOperationalStore(options =>
			   {
				   options.ConfigureDbContext = builder =>
					   builder.UseMySql(conn,
						   sql => sql.MigrationsAssembly(migrationsAssembly));

					// this enables automatic token cleanup. this is optional.
					options.EnableTokenCleanup = false;//�Ƿ�����ݿ�����������ݣ�Ĭ��Ϊfalse
					options.TokenCleanupInterval = 300;//���ƹ���ʱ�䣬Ĭ��Ϊ3600�룬һ��Сʱ
				});

			services.AddControllers();
		}


		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentityServer();

			//app.UseRouting();

			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapGet("/", async context =>
			//	{
			//		await context.Response.WriteAsync("Hello World!");
			//	});
			//});
		}
	}
}
