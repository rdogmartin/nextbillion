using System.Text.Json.Serialization;

namespace NextBillion.Models;

public record class RouteOptimizationResult(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("result")] RouteResult Result,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("message")] string Message
);

public record class RouteResult(
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("summary")] RouteSummary Summary,
    [property: JsonPropertyName("unassigned")] UnassignedJob[] Unassigned,
    [property: JsonPropertyName("routes")] OptimizedRoute[] Routes,
    [property: JsonPropertyName("routing_profiles")] object RoutingProfiles,
    [property: JsonPropertyName("error")] string? Error
);

public record class RouteSummary(
    [property: JsonPropertyName("cost")] decimal Cost,
    [property: JsonPropertyName("routes")] int Routes,
    [property: JsonPropertyName("unassigned")] int Unassigned,
    [property: JsonPropertyName("duration")] decimal Duration,
    [property: JsonPropertyName("distance")] decimal Distance,
    [property: JsonPropertyName("setup")] decimal Setup,
    [property: JsonPropertyName("service")] decimal Service,
    [property: JsonPropertyName("waiting_time")] decimal WaitingTime,
    [property: JsonPropertyName("priority")] decimal Priority,
    [property: JsonPropertyName("delivery")] decimal[] Delivery,
    [property: JsonPropertyName("pickup")] decimal[] Pickup,
    [property: JsonPropertyName("revenue")] decimal? Revenue,
    [property: JsonPropertyName("total_visit_lateness")] decimal? TotalVisitLateness,
    [property: JsonPropertyName("num_late_visits")] int? NumLateVisits
);

public record class UnassignedJob(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("location")] decimal[] Location,
    [property: JsonPropertyName("reason")] string Reason,
    [property: JsonPropertyName("outsourcing_cost")] decimal? OutsourcingCost
);

public record class OptimizedRoute(
    [property: JsonPropertyName("vehicle")] string Vehicle,
    [property: JsonPropertyName("cost")] decimal Cost,
    [property: JsonPropertyName("steps")] RouteStep[] Steps,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("distance")] decimal Distance,
    [property: JsonPropertyName("duration")] decimal Duration,
    [property: JsonPropertyName("geometry")] string Geometry,
    [property: JsonPropertyName("pickup")] decimal[] Pickup,
    [property: JsonPropertyName("delivery")] decimal[] Delivery,
    [property: JsonPropertyName("priority")] decimal Priority,
    [property: JsonPropertyName("service")] decimal Service,
    [property: JsonPropertyName("vehicle_overtime")] decimal? VehicleOvertime,
    [property: JsonPropertyName("waiting_time")] decimal WaitingTime,
    [property: JsonPropertyName("setup")] decimal Setup,
    [property: JsonPropertyName("revenue")] decimal? Revenue,
    [property: JsonPropertyName("profile")] string Profile,
    [property: JsonPropertyName("adopted_capacity")] decimal[] AdoptedCapacity,
    [property: JsonPropertyName("internal_id")] int InternalId
);

/// <summary>
/// Represents a step in an optimized route.
/// </summary>
/// <param name="Id">The identifier for this route step. Uses StringOrInt type because the API may return either a string or integer value depending on the context.</param>
public record class RouteStep(
    [property: JsonPropertyName("id")] StringOrInt Id,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("arrival")] long Arrival,
    [property: JsonPropertyName("duration")] decimal Duration,
    [property: JsonPropertyName("location")] decimal[] Location,
    [property: JsonPropertyName("projected_location")] decimal[]? ProjectedLocation,
    [property: JsonPropertyName("location_index")] int LocationIndex,
    [property: JsonPropertyName("load")] decimal[] Load,
    [property: JsonPropertyName("service")] decimal Service,
    [property: JsonPropertyName("waiting_time")] decimal WaitingTime,
    [property: JsonPropertyName("setup")] decimal Setup,
    [property: JsonPropertyName("late_by")] string? LateBy,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("distance")] decimal Distance,
    [property: JsonPropertyName("snapped_location")] decimal[] SnappedLocation,
    [property: JsonPropertyName("run")] int? Run,
    [property: JsonPropertyName("depot")] string? Depot,
    [property: JsonPropertyName("internal_id")] int? InternalId
);
