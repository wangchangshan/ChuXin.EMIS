using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.Entities;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();

        DataTable GetStudents();
    }
}
