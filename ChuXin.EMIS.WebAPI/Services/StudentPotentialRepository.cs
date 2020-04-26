using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Enums;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.ModelsParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChuXin.EMIS.WebAPI.Services
{
	public class StudentPotentialRepository : IStudentPotentialRepository
	{
		private readonly EFDbContext _efContext;
		private ILogger<StudentPotentialRepository> _logger;
		public StudentPotentialRepository(EFDbContext efContext, ILogger<StudentPotentialRepository> logger)
		{
			_efContext = efContext;
			_logger = logger;
		}

		public void AddStuPotential(StudentPotential stuPotential)
		{
			if (stuPotential == null)
			{
				throw new ArgumentNullException(nameof(stuPotential));
			}

			stuPotential.TrialResult = TrailResultEnum.待定;
			stuPotential.CreateTime = DateTime.Now;
			stuPotential.LineFlag = LineFlagEnum.正常数据;
			_efContext.StudentsPotential.Add(stuPotential);
		}

		public void DeleteStuPotential(StudentPotential stuPotential)
		{
			_efContext.StudentsPotential.Remove(stuPotential);
		}

		public async Task<bool> ExistAsync(int stuPotentialId)
		{
			return await _efContext.StudentsPotential.AnyAsync(x => x.Id == stuPotentialId && x.LineFlag == LineFlagEnum.正常数据);
		}

		public async Task<StudentPotential> GetStuPotentialAsnyc(int stuPotentialId)
		{
			return await _efContext.StudentsPotential.FirstOrDefaultAsync(x => x.Id == stuPotentialId && x.LineFlag == LineFlagEnum.正常数据);
		}

		public async Task<PagedList<StudentPotential>> GetStuPotentialListAsync(StudentPotentialListDtoParams parameters)
		{
			var queryExpression = _efContext.StudentsPotential as IQueryable<StudentPotential>;
			if (!string.IsNullOrWhiteSpace(parameters.StudentName))
			{
				parameters.StudentName = parameters.StudentName.Trim();
				queryExpression = queryExpression.Where(x => EF.Functions.Like(x.StudentName, $"%{parameters.StudentName}%"));
			}

			if (Enum.IsDefined(typeof(TrailResultEnum), parameters.TrialResult))
			{
				queryExpression = queryExpression.Where(x => x.TrialResult == parameters.TrialResult);
			}

			queryExpression = queryExpression.Where(x => x.LineFlag == LineFlagEnum.正常数据);
			queryExpression.OrderBy(x => x.Id);

			return await PagedList<StudentPotential>.CreateAsync(queryExpression, parameters.PageNumber, parameters.PageSize);
		}

		public async Task<bool> SaveAsync()
		{
			return await _efContext.SaveChangesAsync() >= 0;
		}

		public void UpdateStuPotential(StudentPotential stuPotential)
		{
			// EF 不需要写
		}
	}
}
