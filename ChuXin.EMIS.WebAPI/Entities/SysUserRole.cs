using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{/// <summary>
 /// 用户角色映射表
 /// </summary>
	[Table("sys_user_role")]
	public class SysUserRole
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("login_code")]
		[Required]
		[MaxLength(20)]
		public string LoginCode { get; set; }

		[Column("role_id")]
		[Required]
		[MaxLength(10)]
		public string RoleId { set; get; }
	}
}
