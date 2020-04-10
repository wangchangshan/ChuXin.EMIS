using Microsoft.Extensions.Configuration;

namespace ChuXin.EMIS.WebAPI.Helpers
{
	/// <summary>
	/// 用于获取 EMISSetting 配置节点的值
	/// </summary>
	public static class AppSettingHelper
	{
		private static IConfigurationSection _appSection = null;

		public static void InitSetting(IConfigurationSection section)
		{
			_appSection = section;
		}

		public static string GetSetting(string key)
		{
			string rtnValue = string.Empty;
			if (_appSection.GetSection(key) != null)
			{
				rtnValue = _appSection.GetSection(key).Value;
			}

			return rtnValue;
		}
	}
}
