using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 排课模板详细信息表
	/// </summary>
	[Table("schedule_template_dtl")]
	public class ScheduleTemplateDtl
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("sch_template_id")]
		[Required]
		public Guid SchTemplateId { get; set; }

		[Column("course_period")]
		[Required]
		[MaxLength(20)]
		public string CoursePeriod { get; set; }

		[Column("week_index")]
		[Required]
		public WeekEnum WeekIndex { get; set; }
	}
}
