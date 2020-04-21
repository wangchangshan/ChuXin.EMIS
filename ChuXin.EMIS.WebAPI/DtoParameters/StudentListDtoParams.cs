using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.DtoParameters
{
	public class StudentListDtoParams
	{
		public string StudentName { get; set; }

		public StudentStatusEnum StudentStatus { get; set; }

		public string OrderBy { get; set; } = "Id";

		public int PageNumber { get; set; } = 1;

		private int _pageSize = 15;
		private const int MaxPageSize = 100;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}
	}
}
