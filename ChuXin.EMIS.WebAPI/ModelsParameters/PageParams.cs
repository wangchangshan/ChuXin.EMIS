namespace ChuXin.EMIS.WebAPI.ModelsParameters
{
	public abstract class PageParams
	{
		private int _pageSize = 15;
		private const int MaxPageSize = 100;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
		}

		public int PageNumber { get; set; } = 1;
	}
}
