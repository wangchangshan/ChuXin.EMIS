using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChuXin.EMIS.WebAPI.Entities
{
	[Table("sys_login_history")]
	public class SysLoginHistory
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("login_code")]
		public string LoginCode { get; set; }

		[Column("login_ip")]
		public string LoginIp { get; set; }


		[Column("login_time")]
		public DateTime LoginTime { get; set; }
	}
}
