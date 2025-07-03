# NextBillion Route Optimization API

A .NET 9 Web API wrapper for the NextBillion.ai route optimization service. This project provides a simple REST API to submit route optimization problems and retrieve optimized solutions.

This repository also contains sample JSON inputs and outputs for Google Maps Route Optimization (GMPro) and ESRI, although there isn't any code to execute those scenarios directly.

## Overview

This application serves as a proxy/wrapper around the NextBillion.ai optimization API, allowing you to:
- Submit route optimization requests with jobs, vehicles, and locations
- Retrieve optimization results by job ID
- Work with various route optimization scenarios including pickups, deliveries, shipments, and depot management

## API Endpoints

### Submit Route Optimization Request
```http
POST /route
Content-Type: application/json

{
  "description": "Route optimization scenario",
  "jobs": [...],
  "vehicles": [...],
  "locations": {...}
}
```

### Get Optimization Result
```http
GET /route/{id}
```
