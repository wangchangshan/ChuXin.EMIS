using System;
using System.Threading.Tasks;
using ChuXin.EMIS.WebAPI.Entities;
using ChuXin.EMIS.WebAPI.Helpers;

namespace ChuXin.EMIS.WebAPI.IServices
{
    public interface IStudentRepository
    {
        Task<PagedList<Student>> GetStudentsAsync();
    }
}
