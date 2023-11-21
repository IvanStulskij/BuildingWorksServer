namespace BuildingWorks.Common.Configuration;

public class CommonSettings
{
    public string[] CorsAllowedHosts { get; set; } = Array.Empty<string>();
    public string SmsNotificationAccountSid { get; set; } = string.Empty;
    public string SmsNotificationAuthToken { get; set; } = string.Empty;
}
