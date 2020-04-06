using System;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.IServices;

namespace ChuXin.EMIS.WebAPI.Services
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
        }

        public Task<PagedList<Student>> GetStudentsAsync()
        {
            //
        }
    }
}
