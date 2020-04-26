using ChuXin.EMIS.WebAPI.Enums;

namespace ChuXin.EMIS.WebAPI.ModelsParameters
{
	public class StudentPotentialListDtoParams : PageParams
	{
		public string StudentName { get; set; }

		public TrailResultEnum TrialResult { get; set; }
	}
}
