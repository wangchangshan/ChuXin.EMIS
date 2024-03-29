﻿using ChuXin.EMIS.WebAPI.Enums;
using System;

namespace ChuXin.EMIS.WebAPI.Models
{
	public class StudentListDto
	{
		public int Id { get; set; }

		public string StudentCode { get; set; }

		public string StudentName { get; set; }

		public string StudentGenderDisplay { get; set; }

		public DateTime StudentBirthday { get; set; }

		public string StudentPhone { get; set; }

		public string StudentAddress { get; set; }

		public string StudentAvatarPath { get; set; }

		public string StudentStatusDisplay { get; set; }
	}
}
