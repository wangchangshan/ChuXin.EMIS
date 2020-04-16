using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChuXin.EMIS.WebAPI.DtoParameters;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Models;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.JsonPatch;
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
        /// 获取正式学员列表 也可用于导出学员列表
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync([FromQuery] StudentListDtoParameters parameters)
        {
            parameters.PageSize = 15;
            var studentList = await _studentRepository.GetStudentListAsync(parameters);
            var studentListDto = _mapper.Map<IEnumerable<StudentListDto>>(studentList);
            return Ok(studentListDto);
        }

        /// <summary>
        /// 添加正式学员
        /// </summary>
        /// <param name="studentAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] StudentAddDto studentAddDto)
        {
            var student = _mapper.Map<Student>(studentAddDto);

            string studentCode = TableCodeHelper.GenerateCode("student", "student_code", studentAddDto.StudentRegisterDate);
            student.StudentCode = studentCode;
            _studentRepository.AddStudent(student);
            bool flag = await _studentRepository.SaveAsync();
            if (flag)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 局部更新正式学员基本信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="studentUpateDto"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int Id, [FromBody] JsonPatchDocument<StudentUpdateDto> patchDocument)
        {
            if (!await _studentRepository.ExistAsync(Id))
            {
                return NotFound();
            }

            var studentEntity = await _studentRepository.GetStudentAsnyc(Id);
            var dtoToPatch = _mapper.Map<StudentUpdateDto>(studentEntity);

            patchDocument.ApplyTo(patchDocument, ModelState);

            return Ok();
        }
    }
}
