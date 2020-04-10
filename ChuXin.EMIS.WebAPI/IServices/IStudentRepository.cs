using System.Data;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.DtoParameters;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentRepository
    {
        Task<PagedList<Student>> GetStudentListAsync(StudentListDtoParameters parameters);

        DataTable GetStudents();
    }
}
