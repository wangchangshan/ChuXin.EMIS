using System.Data;
using System.Data.Common;

namespace ChuXin.EMIS.WebAPI.DataBaseContext
{
	public interface IAdoRepository
	{
		DataTable GetDataTable(string sql, params object[] args);
		DbCommand CreateCommand(DbProviderFactory factory, params object[] args);
	}
}
