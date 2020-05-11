using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 课程试听（体验）学员表
	/// </summary>
	[Table("student_course_exprience")]
	public class StudentCourseExperience
	{
		[Key]
		[Column("experience_id")]
		public Guid ExperienceId { get; set; }

		[Column("student_code")]
		[Required]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("course_category_code")]
		[MaxLength(20)]
		public string CourseCategoryCode { get; set; }

		[Column("course_category_name")]
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

		[Column("student_source")]
		[Required]
		public StudentSourceEnum StudentSource { get; set; }

		[Column("course_experience_status")]
		[Required]
		public CourseExperienceStatusEnum CourseExperienceStatus { get; set; }

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
