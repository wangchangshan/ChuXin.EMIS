using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 教师表
	/// </summary>
	[Table("teacher")]
	public class Teacher
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("teacher_code")]
		[Required]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[Required]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("teacher_gender")]
		public GenderEnum TeacherGender { get; set; }

		[Column("teacher_birthday")]
		public DateTime TeacherBirthday { get; set; } = DateTime.MinValue;

		[Column("teacher_identity_id")]
		[MaxLength(18)]
		public string TeacherIdentityId { get; set; }

		[Column("teacher_phone")]
		[MaxLength(15)]
		[Required]
		public string TeacherPhone { get; set; }

		[Column("teacher_register_date")]
		[Required]
		public DateTime TeacherRegisterDate { get; set; }

		[Column("teacher_address")]
		[MaxLength(150)]
		public string TeacherAddress { get; set; }

		[Column("teacher_avatar_path")]
		[MaxLength(150)]
		public string TeacherAvatarPath { get; set; }

		[Column("invitation_code")]
		[StringLength(6)]
		public string InvitationCode { get; set; }

		[Column("teacher_remark")]
		[MaxLength(100)]
		public string TeacherRemark { get; set; }

		[Column("teacher_status")]
		[Required]
		public TeacherStatusEnum TeacherStatus { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }
	}
}
