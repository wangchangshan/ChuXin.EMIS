using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 正式学员表
	/// </summary>
	[Table("student")]
	public class Student
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("student_code")]
		[MaxLength(20)]
		[Required]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[MaxLength(20)]
		[Required]
		public string StudentName { get; set; }

		[Column("student_gender")]
		[Required]
		public GenderEnum StudentGender { get; set; }

		[Column("student_birthday")]
		public DateTime StudentBirthday { get; set; } = DateTime.MinValue;

		[Column("student_identity_id")]
		[MaxLength(18)]
		public string StudentIdentityId { get; set; }

		[Column("student_phone")]
		[MaxLength(15)]
		[Required]
		public string StudentPhone { get; set; }

		[Column("student_register_date")]
		public DateTime StudentRegisterDate { get; set; } = DateTime.Now;

		[Column("student_address")]
		[MaxLength(150)]
		public string StudentAddress { get; set; }

		[Column("student_avatar_path")]
		[MaxLength(150)]
		public string StudentAvatarPath { get; set; }

		[Column("invitation_code")]
		[StringLength(6)]
		public string InvitationCode { get; set; }

		[Column("student_remark")]
		[MaxLength(100)]
		public string StudentRemark { get; set; }

		[Column("student_status")]
		public StudentStatusEnum StudentStatus { get; set; }

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
