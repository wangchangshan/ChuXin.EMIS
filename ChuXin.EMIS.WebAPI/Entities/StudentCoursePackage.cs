using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 学员报名套餐表
	/// </summary>
	[Table("student_course_package")]
	public class StudentCoursePackage
	{
		[Key]
		[Column("stu_course_package_id")]
		public Guid StuCoursePackageId { get; set; }

		[Column("student_code")]
		[Required]
		[MaxLength(20)]
		public string StudentCode { get; set; }

		[Column("student_name")]
		[Required]
		[MaxLength(20)]
		public string StudentName { get; set; }

		[Column("package_code")]
		[Required]
		[MaxLength(20)]
		public string PackageCode { get; set; }

		[Column("package_name")]
		[Required]
		[MaxLength(100)]
		public string PackageName { get; set; }

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

		[Column("package_course_count")]
		[Required]
		public int PackageCourseCount { get; set; }

		[Column("actual_course_count")]
		[Required]
		public int ActualCourseCount { get; set; }

		[Column("flex_course_count")]
		[Required]
		public int FlexCourseCount { get; set; }

		[Column("package_price")]
		[Required]
		public decimal PackagePrice { get; set; }

		[Column("actual_price")]
		[Required]
		public decimal ActualPrice { get; set; }

		[Column("fee_back_amount")]
		public decimal FeeBackAmount { get; set; }

		[Column("is_discount")]
		[Required]
		public DiscountEnum IsDiscount { get; set; }

		[Column("is_payed")]
		[Required]
		public PayedEnum IsPayed { get; set; }

		[Column("payee_code")]
		[MaxLength(20)]
		public string PayeeCode { get; set; }

		[Column("payee_name")]
		[MaxLength(20)]
		public string PayeeName { get; set; }

		[Column("pay_pattern")]
		public PayPatternEnum PayPattern { get; set; }

		[Column("pay_time")]
		public DateTime? PayTime { get; set; }

		[Column("rest_course_count")]
		public int RestCourseCount { get; set; }

		[Column("stu_course_package_status")]
		public StuCoursePackageStatusEnum StuCoursePackageStatus { get; set; }

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
