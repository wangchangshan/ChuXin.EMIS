using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 系统编码生成表
	/// </summary>
	[Table("sys_code_factory")]
	public class SysCodeFactory
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("table_name")]
		[Required]
		[MaxLength(30)]
		public string TableName { get; set; }

		[Column("column_name")]
		[Required]
		[MaxLength(30)]
		public string ColumnName { get; set; }

		[Column("prefix")]
		[Required]
		[MaxLength(10)]
		public string Prefix { get; set; }

		[Column("sequence_length")]
		[Required]
		public int SequenceLength { get; set; }

		[Column("current_num")]
		[Required]
		public int CurrentNum { get; set; }
	}
}
