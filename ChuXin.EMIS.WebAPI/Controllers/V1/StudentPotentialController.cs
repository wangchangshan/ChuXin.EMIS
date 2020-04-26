using AutoMapper;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Enums;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.Models;
using ChuXin.EMIS.WebAPI.ModelsParameters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChuXin.EMIS.WebAPI.Controllers.V1
{
	/// <summary>
	/// 试听学员
	/// </summary>
	[ApiVersion("1.0")]
	[ApiController]
	[Route("api/v{version:ApiVersion}/studentspotential")]
	public class StudentPotentialController: ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IStudentPotentialRepository _studentPotentialRepository;

		public StudentPotentialController(IStudentPotentialRepository studentPotentialRepository, IMapper mapper)
		{
			_studentPotentialRepository = studentPotentialRepository;
			_mapper = mapper;
		}

		/// <summary>
		/// 获取潜在学员列表 也可用于导出学员列表
		/// </summary>
		/// <param name="parameters"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetStudentsAsync([FromQuery] StudentPotentialListDtoParams parameters)
		{
			parameters.PageSize = 15;
			var stuPotentialList = await _studentPotentialRepository.GetStuPotentialListAsync(parameters);
			var stuPotentialListDto = _mapper.Map<IEnumerable<StudentPotentialListDto>>(stuPotentialList);

			return RtnHelper.Success(RtnCodeEnum.Success, stuPotentialListDto);
		}

		/// <summary>
		/// 获取潜在学员详细信息
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("{Id}")]
		public async Task<IActionResult> GetStudentDetail(int Id)
		{
			var stuPotential = await _studentPotentialRepository.GetStuPotentialAsnyc(Id);
			if (stuPotential == null)
			{
				return RtnHelper.Failed(RtnCodeEnum.NotFound, $"没有发现Id为： {Id} 的学员");
			}
			var stuPotentialDto = _mapper.Map<StudentPotentialDto>(stuPotential);

			return RtnHelper.Success(RtnCodeEnum.Success, stuPotentialDto);
		}

		/// <summary>
		/// 添加试听（潜在）学员
		/// </summary>
		/// <param name="stuPotentialAddDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateStudentPotentialAsync([FromBody] StudentPotentialAddDto stuPotentialAddDto)
		{
			var stuPotential = _mapper.Map<StudentPotential>(stuPotentialAddDto);

			string studentCode = TableCodeHelper.GenerateCode("student_potential", "student_code", DateTime.Now);
			stuPotential.StudentCode = studentCode;
			stuPotential.CreateTime = DateTime.Now;

			_studentPotentialRepository.AddStuPotential(stuPotential);
			bool flag = await _studentPotentialRepository.SaveAsync();
			if (flag)
			{
				return RtnHelper.Success(RtnCodeEnum.Success, stuPotential.Id);
			}
			else
			{
				return RtnHelper.Failed(RtnCodeEnum.Failed, "添加失败");
			}
		}

		/// <summary>
		/// 整体更新试听（潜在）学员基本信息
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="stuUpdateDto"></param>
		/// <returns></returns>
		[HttpPut("{Id}")]
		public async Task<IActionResult> UpdateStudentPotential(int Id, [FromBody] StudentPotentialUpdateDto stuUpdateDto)
		{
			var stuPotentialEntity = await _studentPotentialRepository.GetStuPotentialAsnyc(Id);
			if (stuPotentialEntity == null)
			{
				// 没有则新增
				var newStuPotential = _mapper.Map<StudentPotential>(stuUpdateDto);

				string studentCode = TableCodeHelper.GenerateCode("student_potential", "student_code", DateTime.Now);
				newStuPotential.StudentCode = studentCode;
				newStuPotential.CreateTime = DateTime.Now;

				_studentPotentialRepository.AddStuPotential(newStuPotential);
				await _studentPotentialRepository.SaveAsync();
				Id = newStuPotential.Id;
			}
			else
			{
				_mapper.Map(stuUpdateDto, stuPotentialEntity);
				_studentPotentialRepository.UpdateStuPotential(stuPotentialEntity);

				await _studentPotentialRepository.SaveAsync();
			}
			return RtnHelper.Success(RtnCodeEnum.Success, Id);
		}

		/// <summary>
		/// 局部更新试听（潜在）学员基本信息
		/// </summary>
		/// <param name="Id"></param>
		/// <param name="patchDocument"></param>
		/// <returns></returns>
		[HttpPatch("{Id}")]
		public async Task<IActionResult> PartiallyUpdateStudentPotential([FromRoute] int Id, [FromBody] JsonPatchDocument<StudentPotentialUpdateDto> patchDocument)
		{
			var stuPotentialEntity = await _studentPotentialRepository.GetStuPotentialAsnyc(Id);
			if (stuPotentialEntity == null)
			{
				// 没有则新增
				var stuPotentialUpdateDto = new StudentPotentialUpdateDto();
				patchDocument.ApplyTo(stuPotentialUpdateDto, ModelState);

				if (!TryValidateModel(stuPotentialUpdateDto))
				{
					return RtnHelper.Failed(RtnCodeEnum.ModelInvalid, ValidationProblem(ModelState), "模型验证错误");
				}

				var newStuPotential = _mapper.Map<StudentPotential>(stuPotentialUpdateDto);
				string studentCode = TableCodeHelper.GenerateCode("student_potential", "student_code", DateTime.Now);
				newStuPotential.StudentCode = studentCode;
				newStuPotential.CreateTime = DateTime.Now;

				_studentPotentialRepository.AddStuPotential(newStuPotential);
				await _studentPotentialRepository.SaveAsync();

				return RtnHelper.Success(RtnCodeEnum.Success, newStuPotential.Id);
			}

			var dtoToPatch = _mapper.Map<StudentPotentialUpdateDto>(stuPotentialEntity);

			patchDocument.ApplyTo(dtoToPatch, ModelState);
			if (!TryValidateModel(dtoToPatch))
			{
				return ValidationProblem(ModelState);
			}

			_mapper.Map(dtoToPatch, stuPotentialEntity);
			_studentPotentialRepository.UpdateStuPotential(stuPotentialEntity);

			await _studentPotentialRepository.SaveAsync();

			return RtnHelper.Success(RtnCodeEnum.Success, Id);
		}

		/// <summary>
		/// 删除试听（潜在）正式学员
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteStudentPotential(int Id)
		{
			var stuPotentialEntity = await _studentPotentialRepository.GetStuPotentialAsnyc(Id);
			if (stuPotentialEntity == null)
			{
				return NotFound();
			}

			_studentPotentialRepository.DeleteStuPotential(stuPotentialEntity);

			await _studentPotentialRepository.SaveAsync();

			return RtnHelper.Success();
		}
	}
}
