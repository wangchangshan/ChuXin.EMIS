using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

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
