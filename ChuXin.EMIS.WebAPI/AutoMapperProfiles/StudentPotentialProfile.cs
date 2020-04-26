using AutoMapper;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.Models;

namespace ChuXin.EMIS.WebAPI.AutoMapperProfiles
{
	public class StudentPotentialProfile: Profile
	{
		public StudentPotentialProfile()
		{
			string host = AppSettingHelper.GetSetting("AccessUrl");

			CreateMap<StudentPotential, StudentPotentialDto>()
				.ForMember(dest => dest.StudentAvatarPath, opt => opt.MapFrom(s => $"{host}api/upload/getimage?id={s.Id}&type=avatar-s"))
				.ForMember(dest => dest.StudentGenderDisplay, opt => opt.MapFrom(s => s.StudentGender.ToString()))
				.ForMember(dest => dest.TrialResultDisplay, opt => opt.MapFrom(s => s.TrialResult.ToString()));

			CreateMap<StudentPotential, StudentPotentialListDto>()
			.ForMember(dest => dest.StudentAvatarPath, opt => opt.MapFrom(s => $"{host}api/upload/getimage?id={s.Id}&type=avatar-s"))
			.ForMember(dest => dest.StudentGenderDisplay, opt => opt.MapFrom(s => s.StudentGender.ToString()))
			.ForMember(dest => dest.TrialResultDisplay, opt => opt.MapFrom(s => s.TrialResult.ToString()));

			CreateMap<StudentPotentialAddDto, StudentPotential>();

			CreateMap<StudentPotentialUpdateDto, StudentPotential>();

			CreateMap<StudentPotential, StudentPotentialUpdateDto>();
		}
	}
}
