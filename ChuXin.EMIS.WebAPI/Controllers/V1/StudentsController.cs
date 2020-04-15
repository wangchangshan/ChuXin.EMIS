using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChuXin.EMIS.WebAPI.DtoParameters;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Models;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChuXin.EMIS.WebAPI.Controllers.V1
{
	/// <summary>
	/// 正式学员
	/// </summary>
	[ApiVersion("1.0")]
	[ApiController]
	[Route("api/v{version:ApiVersion}/students")]
	public class StudentsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IOptions<AppSetting> _appOptions;
		private readonly IStudentRepository _studentRepository;
		public StudentsController(IStudentRepository studentRepository, IMapper mapper)
		{
			_mapper = mapper;
			_studentRepository = studentRepository;
		}

		/// <summary>
		/// 获取正式学员列表
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetStudents([FromQuery] StudentListDtoParameters parameters)
		{
			parameters.PageSize = 15;
			var studentList = await _studentRepository.GetStudentListAsync(parameters);
			var studentListDto = _mapper.Map<IEnumerable<StudentListDto>>(studentList);
			return Ok(studentListDto);
		}
	}
}
