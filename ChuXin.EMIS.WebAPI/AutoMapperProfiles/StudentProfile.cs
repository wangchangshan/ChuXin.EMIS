using AutoMapper;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Models;

namespace ChuXin.EMIS.WebAPI.AutoMapperProfiles
{
	public class StudentProfile: Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, StudentListDto>();
		}
	}
}
