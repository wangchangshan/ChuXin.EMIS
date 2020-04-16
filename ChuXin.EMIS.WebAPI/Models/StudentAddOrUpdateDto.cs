using System;

namespace ChuXin.EMIS.WebAPI.Models
{
	public abstract class StudentAddOrUpdateDto
	{
		public string StudentName { get; set; }

		public string StudentSex { get; set; }

		public DateTime StudentBirthday { get; set; } = DateTime.MinValue;

		public string StudentIdentityCardNum { get; set; }

		public string StudentPhone { get; set; }

		public string StudentAddress { get; set; }

		public string StudentRemark { get; set; }

		public DateTime StudentRegisterDate { get; set; } = DateTime.Now;

		public string StudentStatus { get; set; }
	}
}
