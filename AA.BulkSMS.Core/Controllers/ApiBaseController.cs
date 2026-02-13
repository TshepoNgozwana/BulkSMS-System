using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TsaScoreCard.Core.Models;

namespace TsaScoreCard.Core.Controllers
{
    public abstract class ApiBaseController : Controller
    {
        protected readonly ILogger<ApiBaseController> _logger;
        protected readonly IConfiguration _configuration;
        protected readonly string _environment;

        public BaseModel BaseModel { get; set; }

        protected ApiBaseController(ILogger<ApiBaseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _environment = _configuration["AppSettings:Environment"];
            BaseModel = new BaseModel
            {
                WelcomeMessage = "Welcome to the TSA Score Card System!"
            };


        }
    }
}
