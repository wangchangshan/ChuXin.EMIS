using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.ModelsParameters;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentRepository
    {
        // DataTable GetStudents();  Test Ado.Net

        Task<Student> GetStudentAsnyc(int studentId);

        Task<PagedList<Student>> GetStudentListAsync(StudentListDtoParams parameters);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        Task<bool> ExistAsync(int studentId);

        Task<bool> SaveAsync();
    }
}
