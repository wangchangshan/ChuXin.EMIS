using System;

namespace ChuXin.EMIS.WebAPI.Models
{
	public class StudentDto
	{
		public int Id { get; set; }

		public string StudentCode { get; set; }

		public string StudentName { get; set; }

		public string StudentGenderDisplay { get; set; }

		public DateTime StudentBirthday { get; set; }

		public string StudentIdentityId { get; set; }

		public string StudentPhone { get; set; }

		public string StudentAddress { get; set; }

		public string StudentAvatarPath { get; set; }

		public string StudentRemark { get; set; }

		public DateTime StudentRegisterDate { get; set; }

		public string StudentStatusDisplay { get; set; }
	}
}
