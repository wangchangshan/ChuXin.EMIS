using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 字典表
	/// </summary>
	[Table("sys_dictionary")]
	public class SysDictionary
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("type_code")]
		[Required]
		[MaxLength(20)]
		public string TypeCode { get; set; }

		[Column("type_name")]
		[Required]
		[MaxLength(40)]
		public string TypeName { get; set; }

		[Column("item_code")]
		[Required]
		[MaxLength(20)]
		public string ItemCode { get; set; }

		[Column("item_name")]
		[Required]
		[MaxLength(40)]
		public string ItemName { get; set; }

		[Column("item_desc")]
		[Required]
		[MaxLength(60)]
		public string ItemDesc { get; set; }

		[Column("is_parent")]
		[Required]
		public bool IsParent { get; set; }

		[Column("parent_item_code")]
		[MaxLength(20)]
		public string ParentItemCode { get; set; }

		[Column("item_sort_weight")]
		[StringLength(3)]
		public string ItemSortWeight { get; set; }

		[Column("is_enabled")]
		public EnabledEnum IsEnabled { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime CreateTime { get; set; }
	}
}
