using ChuXin.EMIS.IDP.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.IDP.Entities
{
	/// <summary>
	/// 系统用户表（添加教师即写入当前表）
	/// </summary>
	[Table("sys_user")]
	public class SysUser
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("login_code")]
		[Required]
		[MaxLength(20)]
		public string LoginCode { get; set; }

		[Column("pwd")]
		[Required]
		[MaxLength(50)]
		public string Pwd { get; set; }

		[Column("enabled_login")]
		[Required]
		public EnabledEnum EnabledLogin { get; set; }

		[Column("nick_name")]
		[MaxLength(20)]
		public string NickName { get; set; }

		[Column("is_teacher")]
		[Required]
		public bool IsTeacher { get; set; }

		[Column("teacher_code")]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("access_token")]
		public Guid AccessToken { get; set; }

		[Column("access_expire_time")]
		public DateTime? TokenExpireTime { get; set; }

		[Column("is_locked")]
		[Required]
		public bool IsLocked { get; set; }

		[Column("last_login_time")]
		public DateTime? LastLoginTime { get; set; }

		[Column("last_login_ip")]
		[MaxLength(45)]
		public string LastLoginIP { get; set; }

		[Column("org_id")]
		[Required]
		public Guid OrgId { get; set; }

		[Column("create_by")]
		[MaxLength(20)]
		public string CreateBy { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime? CreateTime { get; set; }

		[Column("delete_by")]
		[MaxLength(20)]
		public string DeleteBy { get; set; }

		[Column("delete_time")]
		public DateTime? DeleteTime { get; set; }

		[Column("line_flag")]
		[Required]
		public LineFlagEnum LineFlag { get; set; }
	}
}
