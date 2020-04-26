using System;
namespace ChuXin.EMIS.WebAPI.Enums
{
    public enum RtnCodeEnum
    {
        Success = 2000,

        NeedLogin = 3000,

        AccountLocked = 3100,

        NoPermission = 3200,

        NotFound = 4040,

        Failed = 5000,

        ModelInvalid = 5100
    }
}
