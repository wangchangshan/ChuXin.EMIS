﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 课程套餐表
	/// </summary>
	[Table("course_package")]
	public class CoursePackage : AbCommonField
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("package_code")]
		[Required]
		[MaxLength(20)]
		public string PackageCode { get; set; }

		[Column("package_name")]
		[Required]
		[MaxLength(100)]
		public string PackageName { get; set; }

		[Column("package_course_category_code")]
		[Required]
		[MaxLength(20)]
		public string PackageCourseCategoryCode { get; set; }

		[Column("package_course_category_name")]
		[Required]
		[MaxLength(20)]
		public string PackageCourseCategoryName { get; set; }

		[Column("package_course_count")]
		[Required]
		public int PackageCourseCount { get; set; }

		[Column("package_price")]
		[Required]
		public decimal PackagePrice { get; set; }

		[Column("package_enabled")]
		public EnabledEnum PackageEnabled { get; set; }
	}
}
