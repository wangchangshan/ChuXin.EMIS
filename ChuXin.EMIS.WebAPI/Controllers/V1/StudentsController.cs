using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Enums;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Models;
using ChuXin.EMIS.WebAPI.ModelsParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChuXin.EMIS.WebAPI.Controllers.V1
{
    /// <summary>
    /// 正式学员
    /// </summary>
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v{version:ApiVersion}/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
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
        public async Task<IActionResult> GetStudentsAsync([FromQuery] StudentListDtoParams parameters)
        {
            parameters.PageSize = 15;
            var studentList = await _studentRepository.GetStudentListAsync(parameters);
            var studentListDto = _mapper.Map<IEnumerable<StudentListDto>>(studentList);

            return RtnHelper.Success(RtnCodeEnum.Success, studentListDto);
        }

        /// <summary>
        /// 获取正式学员详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetStudentDetail(int Id)
        {
            var student = await _studentRepository.GetStudentAsnyc(Id);
            if (student == null)
            {
                return RtnHelper.Failed(RtnCodeEnum.NotFound, $"没有发现Id为： {Id} 的学员");
            }
            var studentDto = _mapper.Map<StudentDto>(student);

            return RtnHelper.Success(RtnCodeEnum.Success, studentDto);
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
                return RtnHelper.Success(RtnCodeEnum.Success, student.Id);
            }
            else
            {
                return RtnHelper.Failed(RtnCodeEnum.Failed, "添加正式学员失败！");
            }
        }

        /// <summary>
        /// 整体更新正式学员基本信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="studentUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateStudent(int Id, [FromBody] StudentUpdateDto studentUpdateDto)
        {
            var studentEntity = await _studentRepository.GetStudentAsnyc(Id);
            if (studentEntity == null)
            {
                // 没有则新增
                var newStudent = _mapper.Map<Student>(studentUpdateDto);

                string studentCode = TableCodeHelper.GenerateCode("student", "student_code", newStudent.StudentRegisterDate);
                newStudent.StudentCode = studentCode;

                _studentRepository.AddStudent(newStudent);
                await _studentRepository.SaveAsync();
                Id = newStudent.Id;
            }
            else
            {
                _mapper.Map(studentUpdateDto, studentEntity);
                _studentRepository.UpdateStudent(studentEntity);
                await _studentRepository.SaveAsync();
            }

            return RtnHelper.Success(RtnCodeEnum.Success, Id);
        }

        /// <summary>
        /// 局部更新正式学员基本信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public async Task<IActionResult> PartiallyUpdateStudent([FromRoute] int Id, [FromBody] JsonPatchDocument<StudentUpdateDto> patchDocument)
        {
            var studentEntity = await _studentRepository.GetStudentAsnyc(Id);
            if (studentEntity == null)
            {
                // 没有则新增
                var studentUpdateDto = new StudentUpdateDto();
                patchDocument.ApplyTo(studentUpdateDto, ModelState);

                if (!TryValidateModel(studentUpdateDto))
                {
                    return RtnHelper.Failed(RtnCodeEnum.ModelInvalid, ValidationProblem(ModelState), "模型验证错误");
                }

                var newStudent = _mapper.Map<Student>(studentUpdateDto);
                string studentCode = TableCodeHelper.GenerateCode("student", "student_code", newStudent.StudentRegisterDate);
                newStudent.StudentCode = studentCode;

                _studentRepository.AddStudent(newStudent);
                await _studentRepository.SaveAsync();

                return RtnHelper.Success(RtnCodeEnum.Success, newStudent.Id);
            }

            var dtoToPatch = _mapper.Map<StudentUpdateDto>(studentEntity);

            patchDocument.ApplyTo(dtoToPatch, ModelState);
            if (!TryValidateModel(dtoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(dtoToPatch, studentEntity);
            _studentRepository.UpdateStudent(studentEntity);

            await _studentRepository.SaveAsync();

            return RtnHelper.Success(RtnCodeEnum.Success, Id);
        }

        /// <summary>
        /// 删除正式学员
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var studentEntity = await _studentRepository.GetStudentAsnyc(Id);
            if (studentEntity == null)
            {
                return RtnHelper.Failed(RtnCodeEnum.NotFound, $"没法发现Id为：{Id} 的学员！");
            }

            _studentRepository.DeleteStudent(studentEntity);

            await _studentRepository.SaveAsync();

            return RtnHelper.Success();
        }
    }
}
