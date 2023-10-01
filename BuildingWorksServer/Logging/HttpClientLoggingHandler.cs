namespace BuildingWorksServer.Logging;

public class HttpClientLoggingHandler : DelegatingHandler
{

    private readonly ILogger<HttpClientLoggingHandler> _logger;

    public HttpClientLoggingHandler(ILogger<HttpClientLoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Log request details
        _logger.LogInformation($"Sending request to {request.RequestUri} using method {request.Method}.");

        if (request.Content != null)
        {
            var requestBody = await request.Content.ReadAsStringAsync(cancellationToken);
            _logger.LogInformation($"Request body: {requestBody}");
        }

        var response = await base.SendAsync(request, cancellationToken);

        // Log response details
        if (response.Content != null)
        {
            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Received response from {request.RequestUri} with status code {response.StatusCode}. Body: {responseBody}");
            }
            else
            {
                _logger.LogError($"Received response from {request.RequestUri} with status code {response.StatusCode}. Body: {responseBody}");
            }
        }
        else
        {
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Received response from {request.RequestUri} with status code {response.StatusCode} without body.");
            }
            else
            {
                _logger.LogError($"Received response from {request.RequestUri} with status code {response.StatusCode} without body.");
            }
        }

        return response;
    }


}