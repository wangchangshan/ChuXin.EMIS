using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 学员介绍推荐表
	/// </summary>
	[Table("student_recommendation")]
	public class StudentRecommendation
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("origin_student_code")]
		[Required]
		[MaxLength(20)]
		public string OriginStudentCode { get; set; }

		[Column("origin_student_name")]
		[Required]
		[MaxLength(20)]
		public string OriginStudentName { get; set; }

		[Column("new_student_code")]
		[Required]
		[MaxLength(20)]
		public string NewStudentCode { get; set; }

		[Column("new_student_name")]
		[Required]
		[MaxLength(20)]
		public string NewStudentName { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }
	}
}
