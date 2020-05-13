using ChuXin.EMIS.IDP.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.IDP.DataBaseContext
{
	public class EFDbContext: DbContext
	{
		public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
		{
		}

		public DbSet<SysUser> SysUsers { get; set; }
	}
}
