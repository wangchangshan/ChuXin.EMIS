using System;
using ChuXin.EMIS.WebAPI.SettingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ChuXin.EMIS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IOptions<AppSetting> _appOptions;
        public StudentsController(IOptions<AppSetting> appOptions)
        {
            _appOptions = appOptions;
        }
    }
}
