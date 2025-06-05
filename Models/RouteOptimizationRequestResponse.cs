using System.Text.Json.Serialization;

namespace NextBillion.Models;

public record class RouteOptimizationRequestResponse(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("status")] string Status
);
