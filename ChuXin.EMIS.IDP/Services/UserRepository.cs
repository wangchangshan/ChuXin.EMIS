using ChuXin.EMIS.IDP.DataBaseContext;
using ChuXin.EMIS.IDP.Entities;
using ChuXin.EMIS.IDP.IServices;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChuXin.EMIS.IDP.Services
{
	public class UserRepository : IUserRepository
	{
		private readonly EFDbContext _efContext;
		public UserRepository(EFDbContext efContext)
		{
			_efContext = efContext;
		}
		public async Task<SysUser> GetUserAsync(string userName, string password)
		{
			return await _efContext.SysUsers.FirstOrDefaultAsync(x => x.LoginCode == userName && x.Pwd == password);
		}
	}
}
