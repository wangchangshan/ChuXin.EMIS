using ChuXin.EMIS.WebAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChuXin.EMIS.WebAPI.Helpers
{
    public static class RtnHelper
    {
        public static JsonResult Success()
        {
            return new JsonResult(new
            {
                Code = RtnCodeEnum.Success,
                Result = "",
                Messsage = "操作成功！"
            });
        }

        public static JsonResult Success(RtnCodeEnum responseCode)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = "",
                Messsage = "操作成功！"
            });
        }

        public static JsonResult Success<T>(RtnCodeEnum responseCode, T t)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = t,
                Messsage = "操作成功！"
            });
        }

        public static JsonResult Failed(RtnCodeEnum responseCode, string message)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = "",
                Messsage = message
            });
        }

        public static JsonResult Failed<T>(RtnCodeEnum responseCode, T t, string message)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = t,
                Messsage = message
            });
        }
    }
}
