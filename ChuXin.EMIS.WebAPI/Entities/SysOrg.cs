using ChuXin.EMIS.WebAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	[Table("sys_org")]
	public class SysOrg
	{
		[Key]
		[Column("org_id")]
		public Guid OrgId { get; set; }

		[Column("org_name")]
		[MaxLength(80)]
		[Required]
		public string OrgName { get; set; }

		[Column("org_address")]
		[MaxLength(100)]
		public string OrgAddress { get; set; }

		[Column("juridical_person")]
		[MaxLength(20)]
		[Required]
		public string JuridicalPerson { get; set; }

		[Column("juridical_person_id")]
		[MaxLength(18)]
		public string JuridicalPersonId { get; set; }

		[Column("business_license")]
		[MaxLength(20)]
		public string BusinessLicense { get; set; }

		[Column("prefix_code")]
		[MaxLength(6)]
		public string PrefixCode { get; set; }

		[Column("org_active_time")]
		public DateTime OrgActiveTime { get; set; }

		[Column("org_off_time")]
		public DateTime OrgOffTime { get; set; }

		[Column("org_status")]
		[Required]
		public OrgStatusEnum OrgStatus { get; set; }

		[Column("org_remark")]
		[MaxLength(100)]
		public string OrgRemark { get; set; }

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
