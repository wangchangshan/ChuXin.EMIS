using System;

namespace ChuXin.EMIS.WebAPI.Models
{
    public class StudentListDto
	{
        public int Id { get; set; }

        public string StudentCode { get; set; }

        public string StudentName { get; set; }

        public string StudentSex { get; set; }

        public DateTime StudentBirthday { get; set; }

        public string StudentPhone { get; set; }

        public string StudentAddress { get; set; }

        public string StudentAvatarPath { get; set; }

        public string StudentStatus { get; set; }
    }
}
