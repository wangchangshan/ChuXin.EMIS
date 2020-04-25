using ChuXin.EMIS.WebAPI.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChuXin.EMIS.WebAPI.Helpers
{
    public static class ResponseObj
    {
        public static JsonResult Success<T>(ResponseCodeEnum responseCode, T t)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = t,
                Messsage = "操作成功！"
            });
        }

        public static JsonResult Failed(ResponseCodeEnum responseCode, string message)
        {
            return new JsonResult(new
            {
                Code = responseCode,
                Result = "",
                Messsage = message
            });
        }
    }
}
