using System;
namespace ChuXin.EMIS.WebAPI.SettingModel
{
    public class AppSetting
    {
        public string MySqlConnectionString { get; set; }

        public EMISSetting EMISSetting { get; set; }
    }
}
