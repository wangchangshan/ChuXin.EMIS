using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 排课模板表
	/// </summary>
	[Table("schedule_template")]
	public class ScheduleTemplate
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("sch_template_code")]
		[Required]
        [MaxLength(10)]
		public string SchTemplateCode { get; set; }

		[Column("sch_template_name")]
        [Required]
        [MaxLength(100)]
		public string SchTemplateName { get; set; }

		[Column("sch_template_enabled")]
        [Required]
		public EnabledEnum SchTemplateEnabled { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; } = DateTime.Now;
	}
}
