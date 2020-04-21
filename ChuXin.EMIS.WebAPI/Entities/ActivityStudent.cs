using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 活动参与学员表
	/// </summary>
	[Table("activity_student")]
	public class ActivityStudent : AbCommonField
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
	}
}
