using System;
using System.Data;
using System.Data.Common;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
    public class AdoDbContext : DbContext
    {
        private static ILogger<AdoDbContext> _logger;
        private readonly IOptions<AppSetting> _appOptions;
        public AdoDbContext() : base()
        {
        }

        public AdoDbContext(DbContextOptions<AdoDbContext> options, ILogger<AdoDbContext> logger, IOptions<AppSetting> appOptions) : base(options)
        {
            _logger = logger;
            _appOptions = appOptions;
        }

        public static DataTable GetDataTable(string sql, params object[] args)
        {
            DataTable dt = null;
            try
            {
                using (AdoDbContext adoContext = new AdoDbContext())
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(adoContext.Database.GetDbConnection());
                    using (var cmd = CreateCommand(factory, args))
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = adoContext.Database.GetDbConnection();
                        using (var adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = cmd;
                            dt = new DataTable();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred during SQL query execution {sql}");
            }

            return dt;
        }

        private static DbCommand CreateCommand(DbProviderFactory factory, params object[] args)
        {
            var cmd = factory.CreateCommand();
            // 构造sql参数
            for (int i = 0; i < args.Length; i++)
            {
                if ((args[i] is string || args[i] is int) && i <= (args.Length - 1))
                {
                    MySqlParameter parm = new MySqlParameter
                    {
                        ParameterName = "@" + (i + 1),
                        Value = args[i]
                    };

                    cmd.Parameters.Add(parm);
                }
                else if (args[i] is MySqlParameter)
                {
                    cmd.Parameters.Add((MySqlParameter)args[i]);
                }
                else throw new ArgumentException("Invalid number or type of arguments supplied");
            }
            return cmd;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_appOptions.Value.MySqlConnectionString);
        }
    }
}
