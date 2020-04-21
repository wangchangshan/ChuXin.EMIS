using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 公用数据库字段的抽象
	/// 由于实体类实现后，总是将字段生成在主键之后（可能是mysql问题），因此暂时不用。
	/// </summary>
	public abstract class AbCommonField
	{
		[Column("create_by", Order = 50)]
		[MaxLength(20)]
		public string CreateBy { get; set; }

		[Column("create_time", Order = 51)]
		[Required]
		public DateTime? CreateTime { get; set; }

		[Column("delete_by", Order = 52)]
		[MaxLength(20)]
		public string DeleteBy { get; set; }

		[Column("delete_time", Order = 53)]
		public DateTime? DeleteTime { get; set; }

		[Column("line_flag", Order = 54)]
		[Required]
		public LineFlagEnum LineFlag{ get; set; }
	}
}
