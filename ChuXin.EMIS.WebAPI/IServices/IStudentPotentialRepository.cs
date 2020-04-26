using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;
using ChuXin.EMIS.WebAPI.ModelsParameters;
using System.Threading.Tasks;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentPotentialRepository
	{
        Task<StudentPotential> GetStuPotentialAsnyc(int studentId);

        Task<PagedList<StudentPotential>> GetStuPotentialListAsync(StudentPotentialListDtoParams parameters);

        void AddStuPotential(StudentPotential stuPotential);

        void UpdateStuPotential(StudentPotential stuPotential);

        void DeleteStuPotential(StudentPotential stuPotential);

        Task<bool> ExistAsync(int studentId);

        Task<bool> SaveAsync();
    }
}
