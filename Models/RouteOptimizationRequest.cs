using System.Text.Json.Serialization;

namespace NextBillion.Models;

public record RouteOptimizationRequest(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("jobs")] Job[] Jobs,
    [property: JsonPropertyName("shipments")] Shipment[] Shipments,
    [property: JsonPropertyName("depots")] Depot[] Depots,
    [property: JsonPropertyName("vehicles")] Vehicle[] Vehicles,
    [property: JsonPropertyName("locations")] Locations Locations
);

public record Job(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location_index")] int LocationIndex,
    [property: JsonPropertyName("service")] int Service,
    [property: JsonPropertyName("pickup")] int[] Pickup,
    [property: JsonPropertyName("skills")] int[] Skills,
    [property: JsonPropertyName("time_windows")] long[][] TimeWindows
);

public record Shipment(
    [property: JsonPropertyName("pickup")] ShipmentPickup Pickup,
    [property: JsonPropertyName("delivery")] ShipmentDelivery Delivery,
    [property: JsonPropertyName("skills")] int[] Skills,
    [property: JsonPropertyName("amount")] int[] Amount
);

public record ShipmentPickup(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location_index")] int LocationIndex,
    [property: JsonPropertyName("time_windows")] long[][] TimeWindows
);

public record ShipmentDelivery(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location_index")] int LocationIndex,
    [property: JsonPropertyName("time_windows")] long[][] TimeWindows
);

public record Depot(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location_index")] int LocationIndex
);

public record Vehicle(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("start_index")] int? StartIndex,
    [property: JsonPropertyName("depot")] int? Depot,
    [property: JsonPropertyName("skills")] int[] Skills,
    [property: JsonPropertyName("capacity")] int[] Capacity,
    [property: JsonPropertyName("time_window")] long[] TimeWindow
);

public record Locations(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("location")] string[] Location
);
