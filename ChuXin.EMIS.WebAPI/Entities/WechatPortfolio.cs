using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	/// <summary>
	/// 微信小程序使用的图片
	/// </summary>
	[Table("wechat_portfolio")]
	public class WechatPortfolio
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("doc_type")]
		[Required]
		public WechatDocTypeEnum DocType { get; set; }

		[Column("doc_subject")]
		[Required]
		[MaxLength(50)]
		public string DocSubject { get; set; }

		[Column("doc_path")]
		[Required]
		[MaxLength(150)]
		public string DocPath { get; set; }

		[Column("author_code")]
		[Required]
		[MaxLength(20)]
		public string AuthorCode { get; set; }

		[Column("author_name")]
		[Required]
		[MaxLength(20)]
		public string AuthorName { get; set; }

		[Column("author_avatar_path")]
		[MaxLength(150)]
		public string AuthorAvatarPath { get; set; }

		[Column("author_age")]
		public int? StudentAge { get; set; }

		[Column("author_sex")]
		public GenderEnum StudentSex { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; }
	}
}
