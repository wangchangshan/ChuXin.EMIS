using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.ModelsParameters
{
	public class StudentListDtoParams : PageParams
	{
		public string StudentName { get; set; }

		public StudentStatusEnum StudentStatus { get; set; }
	}
}
