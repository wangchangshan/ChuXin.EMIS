using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChuXin.EMIS.WebAPI.Models
{
	public class StudentPotentialDto
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

		public string TrialResultDisplay { get; set; }

		public string TrialResultReason { get; set; }

		public string StudentRemark { get; set; }
	}
}
