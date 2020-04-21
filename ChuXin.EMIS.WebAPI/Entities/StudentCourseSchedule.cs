using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 课程安排表
	/// </summary>
	[Table("student_course_schedule")]
	public class StudentCourseSchedule
	{
		[Key]
		[Column("stu_course_schedule_id")]
		public Guid StuCourseScheduleId { get; set; }

		[Column("stu_course_package_id")]
		[Required]
		public Guid StuCoursePackageId { get; set; }

		[Column("sch_template_code")]
		[Required]
		[MaxLength(10)]
		public string SchTemplateCode { get; set; }

		[Column("classroom")]
		[Required]
		[MaxLength(20)]
		public string Classroom { get; set; }

		[Column("course_period")]
		[Required]
		[MaxLength(20)]
		public string CoursePeriod { get; set; }

		[Column("week_index")]
		[Required]
		public WeekEnum WeekIndex { get; set; }

		[Column("student_code")]
		[Required]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("course_package_code")]
		[Required]
		[MaxLength(20)]
		public string CoursePackageCode { get; set; }

		[Column("course_total_count")]
		[Required]
		public int CourseTotalCount { get; set; }

		[Column("course_rest_count")]
		[Required]
		public int CourseRestCount { get; set; }

		[Column("course_type")]
		[Required]
		public CourseTypeEnum CourseType { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime CreateTime { get; set; }
	}
}
