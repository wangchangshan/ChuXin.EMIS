using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 系统角色表
	/// </summary>
	[Table("sys_role")]
	public class SysRole
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("role_id")]
		[Required]
		[MaxLength(10)]
		public string RoleId { set; get; }

		[Column("role_name")]
		[Required]
		[MaxLength(20)]
		public string RoleName { set; get; }

		[Column("role_level")]
		[Required]
		public RoleLevelEnum RoleLevel { get; set; }

		[Column("org_id")]
		[Required]
		public Guid OrgId { get; set; }
	}
}
