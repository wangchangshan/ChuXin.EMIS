using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DataBaseContext;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace ChuXin.EMIS.WebAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EFDbContext _efContext;
        public StudentRepository(EFDbContext efContext)
        {
            _efContext = efContext ?? throw new ArgumentNullException(nameof(efContext)); ;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _efContext.Students.ToListAsync();
        }
    }
}
