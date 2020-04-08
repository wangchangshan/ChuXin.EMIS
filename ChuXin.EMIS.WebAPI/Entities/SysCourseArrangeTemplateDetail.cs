using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	[Table("sys_course_arrange_template_detail")]
	public class SysCourseArrangeTemplateDetail
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("arrange_template_code")]
		public string ArrangeTemplateCode { get; set; }

		[Column("course_period")]
		public string CoursePeriod { get; set; }

		[Column("course_week_day")]
		public string CourseWeekDay { get; set; }
	}
}
