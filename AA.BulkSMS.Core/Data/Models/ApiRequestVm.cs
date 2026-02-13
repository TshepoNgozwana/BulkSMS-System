namespace TsaScoreCard.Core.Models;

public class ApiRequestVm
{
    public HttpMethod Method { get; set; }
    public string BaseUrl { get; set; }
    public string JsonPayLoad { get; set; }
    public string ApiEndPoint { get; set; }
    public string? SubscriptionKey { get; set; }

}