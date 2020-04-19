using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
    /// <summary>
    /// 活动图片表
    /// </summary>
	[Table("activity_image")]
	public class ActivityImage
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("temp_uid")]
        [MaxLength(50)]
		public string TempUId { get; set; }

		[Column("activity_id")]
        [Required]
		public Guid ActivityId { get; set; }

		[Column("activity_image_name")]
        [MaxLength(100)]
		public string ActivityImageName { get; set; }

		[Column("activity_image_path")]
        [MaxLength(200)]
        [Required]
		public string ActivityImagePath { get; set; }

		[Column("activity_image_width_height")]
        [MaxLength(20)]
		public string ActivityImageWidthHeight { get; set; }

		[Column("activity_image_size")]
        [Required]
		public int ActivityImageSize { get; set; }

		[Column("create_time")]
		public DateTime CreateTime { get; set; } = DateTime.Now;
	}
}
