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
			////设置开发者临时签名凭据
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
					options.EnableTokenCleanup = false;//是否从数据库清楚令牌数据，默认为false
					options.TokenCleanupInterval = 300;//令牌过期时间，默认为3600秒，一个小时
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
