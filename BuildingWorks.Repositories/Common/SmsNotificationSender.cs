using BuildingWorks.Common.Configuration;
using Microsoft.Extensions.Options;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BuildingWorks.Repositories.Common;

public interface ISmsNotificationSender
{
    Task SendSms(string message, string phone);
}

public class SmsNotificationSender : ISmsNotificationSender
{
    public async Task SendSms(string message, string phone)
    {
        phone = $"+{Regex.Replace(phone, @"\D", string.Empty)}";
        using var port = new SerialPort();
        SetupPortSettings(port);

        port.WriteLine("AT \r\n");
        Thread.Sleep(500);
        port.Write("AT+CMGF=1 \r\n");
        Thread.Sleep(500);
        port.Write($"AT+CMGS=\"{phone}\"" + "\r\n");
        port.Close();
    }

    private void SetupPortSettings(SerialPort port)
    {
        port.BaudRate = 2400;
        port.DataBits = 7;

        port.StopBits = StopBits.One;
        port.Parity = Parity.Odd;

        port.ReadTimeout = 500;
        port.WriteTimeout = 500;

        port.Encoding = Encoding.UTF8;
        port.PortName = "COM4";

        if (port.IsOpen)
        {
            port.Close();
        }

        port.Open();
    }
}

public class ExternalSmsNoficationSender : ISmsNotificationSender
{
    private readonly IOptions<CommonSettings> _options;

    public ExternalSmsNoficationSender(IOptions<CommonSettings> options)
    {
        _options = options;
    }

    public async Task SendSms(string message, string phone)
    {
        TwilioClient.Init(_options.Value.SmsNotificationAccountSid, _options.Value.SmsNotificationAuthToken);
        var responseMessage = await MessageResource.CreateAsync(body: message, to: phone);

        var x = string.Empty;
    }
}
