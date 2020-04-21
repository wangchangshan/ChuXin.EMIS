using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 活动参与学员表
	/// </summary>
	[Table("activity_student")]
	public class ActivityStudent
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("activity_id")]
		[Required]
		public Guid ActivityId { get; set; }

		[Column("student_code")]
		[MaxLength(20)]
		[Required]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[MaxLength(20)]
		[Required]
		public string StudentName { get; set; }

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
