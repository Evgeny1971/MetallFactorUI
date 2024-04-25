using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Serilog;


public class EmailService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<EmailService> _logger;

    public EmailService(HttpClient httpClient,ILogger<EmailService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _logger.LogInformation($"Email sent to ");

    }

    public async Task SendEmailAsync(EmailRequestDTO request)
    {
        Console.WriteLine( "Hello, world!");
        _logger.LogInformation($"Email sent to {request.To[0]} with subject: {request.Subject}");
        return;
        // Call the Web API endpoint to send the email
        var response = await _httpClient.PostAsJsonAsync("email-send", request);
        response.EnsureSuccessStatusCode(); // Ensure success status code (2xx)
    }
}
