using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 课堂评语表
	/// </summary>
	[Table("student_course_comment")]
	public class StudentCourseComment
	{
		[Key]
		[Column("comment_id")]
		public int CommentId { get; set; }

		[Column("course_id")]
		public Guid CourseId { get; set; }

		[Column("student_code")]
		[Required]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("content")]
		[Required]
		[MaxLength(200)]
		public string Content { get; set; }

		[Column("course_date")]
		public DateTime? CourseDate { get; set; }

		[Column("teacher_code")]
		[Required]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[Required]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime CreateTime { get; set; }
	}
}
