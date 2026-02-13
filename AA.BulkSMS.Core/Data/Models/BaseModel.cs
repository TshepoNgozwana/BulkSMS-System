namespace TsaScoreCard.Core.Models;

public class BaseModel
{
    public string PageTitle { get; set; }
    public List<Breadcrumb> Breadcrumbs { get; set; } = new List<Breadcrumb>();
    public string WelcomeMessage { get; set; }
    public string PathToIcon { get; set; }
    public string Caption { get; set; }
    public string ProfilePic { get; set; }
    public Dictionary<string, string> PageStats { get; set; }
    public dynamic UserProfile { get; set; }
}