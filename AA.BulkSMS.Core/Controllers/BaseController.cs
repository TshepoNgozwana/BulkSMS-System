using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TsaScoreCard.Core.Models;

namespace TsaScoreCard.Core.Controllers;

public abstract class BaseController : Controller
{
    protected readonly ILogger<BaseController> _logger;
    protected readonly IConfiguration _configuration;
    protected readonly string _environment;
    protected readonly ApiRequestVm _apiSettings;


    public BaseModel BaseModel { get; set; }

    protected BaseController(ILogger<BaseController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _environment = _configuration["AppSettings:Environment"];
        BaseModel = new BaseModel
        {
            WelcomeMessage = "Welcome to the TSA Scorecard System!"
        };
        _apiSettings = new ApiRequestVm
        {
            BaseUrl = _configuration["ApiSettings:BaseUrl"],
            SubscriptionKey = _configuration["ApiSettings:ApiSubKey"]
        };

    }

    protected void SetPageTitle(string title, string pathToIcon, string caption)
    {
        BaseModel.PageTitle = title;
        BaseModel.PathToIcon = pathToIcon;
        BaseModel.Caption = caption;
    }

    protected void AddBreadcrumb(string title, string url)
    {
        BaseModel.Breadcrumbs.Add(new Breadcrumb() { Title = title, Url = url });
    }

    protected void SetWelcomeMessage(string message)
    {
        BaseModel.WelcomeMessage = message;
    }

    public override ViewResult View(string viewName, object model)
    {
        if (model is BaseModel baseModel)
        {
            baseModel.PageTitle = BaseModel.PageTitle;
            baseModel.Breadcrumbs = BaseModel.Breadcrumbs;
            baseModel.WelcomeMessage = BaseModel.WelcomeMessage;
        }
        return base.View(viewName, model);
    }
}