using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
    /// <summary>
    /// 学员课程记录表
    /// </summary>
	[Table("student_course_list")]
	public class StudentCourseList
	{
		[Key]
		[Column("course_id")]
		public Guid CourseId { get; set; }

		[Column("stu_course_package_id")]
        [Required]
		public Guid StuCoursePackageId { get; set; }

		[Column("stu_course_schedule_id")]
        [Required]
		public Guid StuCourseScheduleId { get; set; }

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

		[Column("course_date")]
        [Required]
		public DateTime CourseDate { get; set; }

		[Column("student_code")]
        [Required]
        [MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("teacher_code")]
		[Required]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[Required]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("course_category_code")]
		[Required]
		[MaxLength(20)]
		public string CourseCategoryCode { get; set; }

		[Column("course_category_name")]
		[Required]
		[MaxLength(20)]
		public string CourseCategoryName { get; set; }

		[Column("course_folder_code")]
		[Required]
		[MaxLength(20)]
		public string CourseFolderCode { get; set; }

		[Column("course_folder_name")]
		[Required]
		[MaxLength(20)]
		public string CourseFolderName { get; set; }

		[Column("course_subject")]
		[Required]
		[MaxLength(100)]
		public string CourseSubject { get; set; }

		[Column("course_type")]
        [Required]
		public CourseTypeEnum CourseType { get; set; }

		[Column("course_status")]
		public CourseStatusEnum CourseStatus { get; set; }

		[Column("activity_id")]
		public Guid ActivityId { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; } = DateTime.Now;
	}
}
