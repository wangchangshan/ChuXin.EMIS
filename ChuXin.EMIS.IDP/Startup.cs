using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
			var builder = services.AddIdentityServer();

			//设置开发者临时签名凭据
			builder.AddDeveloperSigningCredential();
			//builder.AddInMemoryIdentityResources(Config.GetIdentityResources());
			builder.AddInMemoryApiResources(Config.GetApis());
			builder.AddInMemoryClients(Config.GetClients());

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
