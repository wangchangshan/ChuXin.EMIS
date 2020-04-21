using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 活动表
	/// </summary>
	[Table("activity")]
	public class Activity : AbCommonField
	{
		[Key]
		[Column("activity_id")]
		public Guid ActivityId { get; set; }

		[Column("activity_subject")]
		[MaxLength(100)]
		[Required]
		public string ActivitySubject { get; set; }

		[Column("activity_start_date")]
		public DateTime? ActivityStartDate { get; set; }

		[Column("activity_end_date")]
		public DateTime? ActivityEndDate { get; set; }

		[Column("activity_course_count")]
		public int ActivityCourseCount { get; set; }

		[Column("activity_child_price")]
		public decimal ActivityChildPrice { get; set; }

		[Column("activity_adult_price")]
		public decimal ActivityAdultPrice { get; set; }

		[Column("activity_address")]
		[MaxLength(150)]
		[Required]
		public string ActivityAddress { get; set; }

		[Column("activity_content")]
		[MaxLength]
		public string ActivityContent { get; set; }
	}
}
