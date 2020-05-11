using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
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
		[Column("sch_template_id")]
		public Guid SchTemplateId { get; set; }

		[Column("sch_template_name")]
		[Required]
		[MaxLength(100)]
		public string SchTemplateName { get; set; }

		[Column("sch_template_enabled")]
		[Required]
		public EnabledEnum SchTemplateEnabled { get; set; }

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
