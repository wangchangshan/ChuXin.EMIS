using ChuXin.EMIS.WebAPI.DataBaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;

namespace ChuXin.EMIS.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("--------------Init Main------------------");
                var host = CreateHostBuilder(args).Build();

                using (var scope = host.Services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<EFDbContext>();

                    dbContext.Database.EnsureDeleted();
                    // ������ݿⲻ���ڣ��򴴽����ݿ�
                    dbContext.Database.EnsureCreated();
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    // ������־��͵ȼ�  Trace -> Debug -> Info -> Warning -> Error -> Fatal
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                })
                .UseNLog(); // ע��
    }
}
