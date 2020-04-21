using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 系统菜单表
	/// </summary>
	[Table("sys_menu")]
	public class SysMenu
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("menu_name")]
		[Required]
		[MaxLength(20)]
		public string MenuName { get; set; }

		[Column("menu_url")]
		[Required]
		[MaxLength(50)]
		public string MenuUrl { get; set; }

		[Column("menu_component")]
		[Required]
		[MaxLength(50)]
		public string MenuComponent { get; set; }

		[Column("menu_icon")]
		[MaxLength(20)]
		public string MenuIcon { get; set; }

		[Column("menu_meta")]
		public string MenuMeta { get; set; }

		[Column("is_sub_menu")]
		[Required]
		public bool IsSubMenu { get; set; }

		[Column("is_hidden")]
		[Required]
		public bool IsHidden { get; set; }

		[Column("is_enable")]
		[Required]
		public EnabledEnum IsEnable { get; set; }

		[Column("menu_roles")]
		[Required]
		[MaxLength(100)]
		public string MenuRoles { get; set; }

		[Column("sort_weight")]
		[Required]
		[StringLength(3)]
		public string SortWeight { get; set; }

		[Column("create_time")]
		[Required]
		public DateTime CreateTime { get; set; }
	}
}
