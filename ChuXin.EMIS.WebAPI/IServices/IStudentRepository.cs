using System.Data;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DtoParameters;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentRepository
    {
        // DataTable GetStudents();  Test Ado.Net

        Task<PagedList<Student>> GetStudentListAsync(StudentListDtoParameters parameters);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        Task<bool> SaveAsync();
    }
}
