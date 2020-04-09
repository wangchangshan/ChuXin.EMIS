using System;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.IServices;
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
		private readonly IOptions<AppSetting> _appOptions;
		private readonly IStudentRepository _studentRepository;
		private readonly ILogger<StudentsController> _logger;
		public StudentsController(IOptions<AppSetting> appOptions, IStudentRepository studentRepository, ILogger<StudentsController> logger)
		{
			_appOptions = appOptions;
			_studentRepository = studentRepository;
			_logger = logger;

			_logger.LogDebug(1, "NLog injected into HomeController");
		}

		[HttpGet]
		public async Task<IActionResult> GetStudents()
		{
			var studentList = await _studentRepository.GetStudentsAsync();
			var dt = _studentRepository.GetStudents();
			_logger.LogInformation("test");
			return Ok(studentList);
		}
	}
}
