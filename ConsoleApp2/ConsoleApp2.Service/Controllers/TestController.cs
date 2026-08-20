using ConsoleApp2.Service.Tracker;
using Microsoft.AspNetCore.Mvc;
using System.Text;
namespace ConsoleApp2.Service.Controllers;


[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly HttpClient httpClient;
    private readonly ServiceTracker serviceTracker;
    private const string trackerName = "TestController";
    private readonly TrackedObject trackedObject;

    public TestController(HttpClient httpClient, ServiceTracker serviceTracker)
    {
        this.httpClient = httpClient;
        this.serviceTracker = serviceTracker;

        trackedObject = serviceTracker.GetOrAddObject(trackerName);
    }


    [HttpGet("/")]
    public async Task<IActionResult> Get()
    {
        trackedObject.Count++;
        const string endpoint = "http://consoleapp1-service:8080/test/2"; // k8s test
        var result = new StringBuilder();
        result.AppendLine($"API2 is working, podID: {trackedObject.Id}, get request count: {trackedObject.Count}");
        try
        {
            result.AppendLine($"Trying to get '{endpoint}'");
            var response = await httpClient.GetAsync(endpoint);

            result.AppendLine("Got a result: " + System.Text.Json.JsonSerializer.Serialize(response));
        }
        catch (Exception ex)
        {
            result.AppendLine("Failed to get endpoint: " + ex.Message);
        }

        return Ok(result.ToString());
    }


    [HttpGet("/2")]
    public IActionResult Get2()
    {
        var result = new StringBuilder();
        result.AppendLine("API2 is working");

        return Ok(result.ToString());
    }
}

