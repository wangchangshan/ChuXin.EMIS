﻿using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 学员作品文档表
	/// </summary>
	[Table("student_portfolio")]
	public class StudentPortfolio
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("temp_uid")]
		[MaxLength(40)]
		public string TempUId { get; set; }

		[Column("student_code")]
		[Required]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("doc_title")]
		[Required]
		[MaxLength(100)]
		public string DocTitle { get; set; }

		[Column("doc_label")]
		[MaxLength(20)]
		public string DocLabel { get; set; }

		[Column("course_expense")]
		public int CourseExpense { get; set; }

		[Column("doc_type")]
		[Required]
		[MaxLength(10)]
		public string DocType { get; set; }

		[Column("doc_width_height")]
		[MaxLength(20)]
		public string DocWidthHeight { get; set; }

		[Column("doc_size")]
		[Required]
		public int DocSize { get; set; }

		[Column("doc_path")]
		[MaxLength(200)]
		[Required]
		public string DocPath { get; set; }

		[Column("course_id")]
		public Guid CourseId { get; set; }

		[Column("doc_status")]
		[Required]
		public DocStatusEnum DocStatus { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }
	}
}