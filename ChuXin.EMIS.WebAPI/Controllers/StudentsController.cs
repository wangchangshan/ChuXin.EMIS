using System;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChuXin.EMIS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IOptions<AppSetting> _appOptions;
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IOptions<AppSetting> appOptions, IStudentRepository studentRepository)
        {
            _appOptions = appOptions;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var studentList = await _studentRepository.GetStudentsAsync();

            return Ok(studentList);
        }
    }
}
