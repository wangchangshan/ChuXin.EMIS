using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 假期表
	/// </summary>
	[Table("holiday")]
	public class Holiday : AbCommonField
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("take_off_day")]
		[Required]
		public DateTime TakeOffDay { get; set; }

		[Column("week_index")]
		public WeekEnum WeekIndex { get; set; }

		[Column("create_by")]
		[Required]
		public string CreateBy { get; set; }
	}
}
