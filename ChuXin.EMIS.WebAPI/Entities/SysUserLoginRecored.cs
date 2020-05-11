using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 用户登录记录表
	/// </summary>
	[Table("sys_user_login_record")]
	public class SysUserLoginRecored
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("login_code")]
		[Required]
		[MaxLength(20)]
		public string LoginCode { get; set; }

		[Column("login_ip")]
		[Required]
		[MaxLength(45)]
		public string LoginIp { get; set; }

		[Column("login_time")]
		public DateTime LoginTime { get; set; }

		[Column("org_id")]
		[Required]
		public Guid OrgId { get; set; }
	}
}
