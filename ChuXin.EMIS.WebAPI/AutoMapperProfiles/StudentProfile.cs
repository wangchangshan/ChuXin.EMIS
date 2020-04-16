using AutoMapper;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.Models;

namespace ChuXin.EMIS.WebAPI.AutoMapperProfiles
{
	public class StudentProfile : Profile
	{
		public StudentProfile()
		{
			CreateMap<Student, StudentListDto>()
			.ForMember(dest => dest.StudentAvatarPath, opt => opt.MapFrom(s => $"{AppSettingHelper.GetSetting("AccessUrl")}api/upload/getimage?id={s.Id}&type=avatar-s"));

			CreateMap<StudentAddDto, Student>();

			CreateMap<StudentUpdateDto, Student>();
		}
	}
}
