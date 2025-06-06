using System.Text.Json.Serialization;

namespace NextBillion.Models;

public record class RouteOptimizationRequest(
    [property: JsonPropertyName("jobs")] Job[] Jobs,
    [property: JsonPropertyName("vehicles")] Vehicle[] Vehicles,
    [property: JsonPropertyName("locations")] Locations Locations
)
{
    [property: JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [property: JsonPropertyName("shipments")] public Shipment[] Shipments { get; init; } = [];
    [property: JsonPropertyName("depots")] public Depot[] Depots { get; init; } = [];
}

public record class Job(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("location_index")] int LocationIndex
)
{
    [property: JsonPropertyName("service")] public int Service { get; init; } = 0;
    [property: JsonPropertyName("time_windows")] public long[][] TimeWindows { get; init; } = [];
    [property: JsonPropertyName("pickup")] public int[] Pickup { get; init; } = [];
    [property: JsonPropertyName("skills")] public int[] Skills { get; init; } = [];
}

public record class Shipment(
    [property: JsonPropertyName("pickup")] ShipmentPickup Pickup,
    [property: JsonPropertyName("delivery")] ShipmentDelivery Delivery
)
{
    [property: JsonPropertyName("skills")] public int[] Skills { get; init; } = [];
    [property: JsonPropertyName("amount")] public int[] Amount { get; init; } = [];
}

public record class ShipmentPickup(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("location_index")] int LocationIndex
)
{
    [property: JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [property: JsonPropertyName("time_windows")] public long[][] TimeWindows { get; init; } = [];
}

public record class ShipmentDelivery(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("location_index")] int LocationIndex
)
{
    [property: JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [property: JsonPropertyName("time_windows")] public long[][] TimeWindows { get; init; } = [];
}

public record class Depot(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("location_index")] int LocationIndex
)
{
    [property: JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
}

public record class Break(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("time_windows")] long[][] TimeWindows
)
{
    [property: JsonPropertyName("description")] public string Description { get; init; } = string.Empty;
    [property: JsonPropertyName("service")] int Service  { get; init; } = 0;
}

public record class Vehicle([property: JsonPropertyName("id")] string Id)
{
    [property: JsonPropertyName("start_index")] public int? StartIndex { get; init; } = null;
    [property: JsonPropertyName("start_depot_ids")] public string[] StartDepotIds { get; init; } = [];
    [property: JsonPropertyName("end_depot_ids")] public string[] EndDepotIds { get; init; } = [];
    [property: JsonPropertyName("skills")] public int[] Skills { get; init; } = [];
    [property: JsonPropertyName("capacity")] public int[] Capacity { get; init; } = [];
    [property: JsonPropertyName("time_window")] public long[] TimeWindow { get; init; } = [];
    [property: JsonPropertyName("breaks")] public Break[] Breaks { get; init; } = [];
}

public record class Locations(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location")] string[] Location
);
