using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 微信小程序用户表
	/// </summary>
	[Table("sys_user_wechat")]
	public class SysUserWechat
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("open_id")]
		[Required]
		public string OpenId { get; set; }

		/// <summary>
		/// 存储加密后的sessionKey
		/// </summary>
		[Column("session_key")]
		[Required]
		public string SessionKey { get; set; }

		[Column("access_token")]
		public string AccessToken { get; set; }

		[Column("invitation_code")]
		[StringLength(6)]
		public string InvitationCode { get; set; }

		[Column("wx_user_type")]
		[Required]
		public WechatUserTypeEnum wxUserType { get; set; }

		[Column("student_code")]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("teacher_code")]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("last_request_time")]
		public DateTime? LastRequestTime { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime CreateTime { get; set; }
	}
}
