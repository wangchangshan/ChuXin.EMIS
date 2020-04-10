using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Models;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChuXin.EMIS.WebAPI.Controllers
{
	[ApiController]
	[Route("api/students")]
	public class StudentsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IStudentRepository _studentRepository;
		public StudentsController(IStudentRepository studentRepository, IMapper mapper)
		{
			_mapper = mapper;
			_studentRepository = studentRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetStudents()
		{
			var studentList = await _studentRepository.GetStudentsAsync();
			var studentListDto = _mapper.Map<IEnumerable<StudentListDto>>(studentList);
			return Ok(studentListDto);
		}
	}
}
