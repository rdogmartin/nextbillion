using Microsoft.AspNetCore.Mvc;
using NextBillion.Models;
using System.Text.Json;
using System.Text;

namespace NextBillion.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteController : ControllerBase
{
    private readonly ILogger<RouteController> _logger;
    private readonly HttpClient _httpClient;
    private const string BaseUrl = $"https://api.nextbillion.io/optimization/v2";
    private const string ApiKey = "313bd65a9d5d4acf956bfbe7266246d9";

    public RouteController(ILogger<RouteController> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }    [HttpPost()]
    public async Task<ActionResult<RouteOptimizationRequestResponse>> Post([FromBody] RouteOptimizationRequest request)
    {
        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{BaseUrl}?key={ApiKey}", content);
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RouteOptimizationRequestResponse>(responseData) ?? new RouteOptimizationRequestResponse(string.Empty, "Could not deserialize response", "JSON Parse Error");

            return Ok(result);
        }

        return await CreateErrorResponse(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RouteOptimizationResult>> Get(string id)
    {
        var url = $"{BaseUrl}/result?id={id}&key={ApiKey}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            // We assume the response contains the optimized route. If it is not complete, we will get back message: "Job still processing".
            // Prod code will need to handle this case.
            var result = JsonSerializer.Deserialize<RouteOptimizationResult>(responseData);
            return Ok(result);
        }

        return await CreateErrorResponse(response);
    }

    private async Task<BadRequestObjectResult> CreateErrorResponse(HttpResponseMessage response)
    {
        var errorResponse = new
        {
            error = "nextbillion.ai API request failed",
            statusCode = (int)response.StatusCode,
            statusText = response.ReasonPhrase,
            details = await response.Content.ReadAsStringAsync()
        };
        return BadRequest(errorResponse);
    }
}
