using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 教师简历表
	/// </summary>
	[Table("teacher_resume")]
	public class TeacherResume
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("teacher_code")]
		[Required]
		[MaxLength(20)]
		public string TeacherCode { get; set; }

		[Column("teacher_name")]
		[Required]
		[MaxLength(20)]
		public string TeacherName { get; set; }

		[Column("resume_path")]
		[Required]
		[MaxLength(20)]
		public string ResumePath { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }
	}
}
