using ChuXin.EMIS.WebAPI.Enums;
using System;

namespace ChuXin.EMIS.WebAPI.Models
{
	public abstract class StudentPotentialAddOrUpdateDto
	{
		public string StudentName { get; set; }

		public GenderEnum StudentGender { get; set; }

		public DateTime StudentBirthday { get; set; } = DateTime.MinValue;

		public string StudentIdentityId { get; set; }

		public string StudentPhone { get; set; }

		public string StudentAddress { get; set; }

		public string StudentRemark { get; set; }

		public TrailResultEnum TrialResult { get; set; }
	}
}
