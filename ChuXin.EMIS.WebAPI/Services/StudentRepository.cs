using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.Services
{
	public class StudentRepository : IStudentRepository
	{
		private readonly EFDbContext _efContext;
		private readonly IAdoRepository _adoRepository;
		public StudentRepository(EFDbContext efContext, IAdoRepository adoRepository)
		{
			_efContext = efContext ?? throw new ArgumentNullException(nameof(efContext));
			_adoRepository = adoRepository ?? throw new ArgumentNullException(nameof(efContext));
		}

		public async Task<List<Student>> GetStudentsAsync()
		{
			return await _efContext.Students.ToListAsync();
		}

		public DataTable GetStudents()
		{
			return _adoRepository.GetDataTable("select * from student");
		}
	}
}
