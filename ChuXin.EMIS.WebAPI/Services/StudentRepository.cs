using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.DtoParameters;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChuXin.EMIS.WebAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFDbContext _efContext;
        private readonly IAdoRepository _adoRepository;
        private ILogger<StudentRepository> _logger;
        public StudentRepository(EFDbContext efContext, IAdoRepository adoRepository, ILogger<StudentRepository> logger)
        {
            _efContext = efContext ?? throw new ArgumentNullException(nameof(efContext));
            _adoRepository = adoRepository ?? throw new ArgumentNullException(nameof(efContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _efContext.Student.Add(student);
        }

        public void DeleteStudent(Student student)
        {
        }

        public async Task<Student> GetStudentAsnyc(int studentId)
        {
            return await _efContext.Student.FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public async Task<PagedList<Student>> GetStudentListAsync(StudentListDtoParameters parameters)
        {
            if (parameters == null)
            {
                _logger.LogInformation("no parameters in GetStudentListAsync");
                throw new ArgumentNullException(nameof(parameters));
            }

            var queryExpression = _efContext.Student as IQueryable<Student>;
            if (!string.IsNullOrWhiteSpace(parameters.StudentName))
            {
                parameters.StudentName = parameters.StudentName.Trim();
                queryExpression = queryExpression.Where(x => EF.Functions.Like(x.StudentName, $"%{parameters.StudentName}%"));
            }

            if (!string.IsNullOrWhiteSpace(parameters.StudentStatus))
            {
                parameters.StudentStatus = parameters.StudentStatus.Trim();
                queryExpression = queryExpression.Where(x => x.StudentStatus == parameters.StudentStatus);
            }

            queryExpression.OrderBy(x => x.Id);

            return await PagedList<Student>.CreateAsync(queryExpression, parameters.PageNumber, parameters.PageSize);
        }

        //public DataTable GetStudents()
        //{
        //	return _adoRepository.GetDataTable("select * from student");
        //}

        public void UpdateStudent(Student student)
        {
        }

        public async Task<bool> ExistAsync(int studentId)
        {
            return await _efContext.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<bool> SaveAsync()
        {
            return await _efContext.SaveChangesAsync() >= 0;
        }
    }
}
