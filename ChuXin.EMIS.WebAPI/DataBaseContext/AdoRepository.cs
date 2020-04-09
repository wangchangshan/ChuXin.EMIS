using System;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
	public class AdoRepository : IAdoRepository
	{
		private readonly ILogger<AdoRepository> _logger;
		private readonly EFDbContext _efContext;
		public AdoRepository(EFDbContext efContext, ILogger<AdoRepository> logger)
		{
			_efContext = efContext;
			_logger = logger;
		}
		public DataTable GetDataTable(string sql, params object[] args)
		{
			DataTable dt = null;
			try
			{
				_logger.LogInformation("Get Data Table--------------------");
				DbProviderFactory factory = DbProviderFactories.GetFactory(_efContext.Database.GetDbConnection());
				using (var cmd = CreateCommand(factory, args))
				{
					cmd.CommandText = sql;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = _efContext.Database.GetDbConnection();
					using (var adapter = factory.CreateDataAdapter())
					{
						adapter.SelectCommand = cmd;
						dt = new DataTable();
						adapter.Fill(dt);
					}
				}
				_logger.LogInformation($"SQL is: {sql}");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Error occurred during SQL query execution {sql}");
			}

			return dt;
		}

		public DbCommand CreateCommand(DbProviderFactory factory, params object[] args)
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
	}
}
