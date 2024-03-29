﻿using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Enums;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using ChuXin.EMIS.WebAPI.ModelsParameters;
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

            student.StudentStatus = StudentStatusEnum.正常在学;
            student.CreateTime = DateTime.Now;
            student.LineFlag = LineFlagEnum.正常数据;
            _efContext.Students.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _efContext.Students.Remove(student);
        }

        public async Task<Student> GetStudentAsnyc(int studentId)
        {
            return await _efContext.Students.FirstOrDefaultAsync(x => x.Id == studentId && x.LineFlag == LineFlagEnum.正常数据);
        }

        public async Task<PagedList<Student>> GetStudentListAsync(StudentListDtoParams parameters)
        {
            var queryExpression = _efContext.Students as IQueryable<Student>;
            if (!string.IsNullOrWhiteSpace(parameters.StudentName))
            {
                parameters.StudentName = parameters.StudentName.Trim();
                queryExpression = queryExpression.Where(x => EF.Functions.Like(x.StudentName, $"%{parameters.StudentName}%"));
            }

            if (Enum.IsDefined(typeof(StudentStatusEnum), parameters.StudentStatus))
            {
                queryExpression = queryExpression.Where(x => x.StudentStatus == parameters.StudentStatus);
            }

            queryExpression = queryExpression.Where(x => x.LineFlag == LineFlagEnum.正常数据);
            queryExpression.OrderBy(x => x.Id);

            return await PagedList<Student>.CreateAsync(queryExpression, parameters.PageNumber, parameters.PageSize);
        }

        //public DataTable GetStudents()
        //{
        //	return _adoRepository.GetDataTable("select * from student");
        //}

        public void UpdateStudent(Student student)
        {
            // EF 不需要写
        }

        public async Task<bool> ExistAsync(int studentId)
        {
            return await _efContext.Students.AnyAsync(x => x.Id == studentId && x.LineFlag == LineFlagEnum.正常数据);
        }

        public async Task<bool> SaveAsync()
        {
            return await _efContext.SaveChangesAsync() >= 0;
        }
    }
}
