using ChuXin.EMIS.IDP.Entities;
using System.Threading.Tasks;

namespace ChuXin.EMIS.IDP.IServices
{
	public interface IUserRepository
	{
		Task<SysUser> GetUserAsync(string userName, string password);
	}
}
