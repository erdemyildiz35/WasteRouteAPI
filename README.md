# WasteRoute API

A RESTful API for waste management and recycling route optimization built with ASP.NET Core 8.

## Technologies
- ASP.NET Core 8
- Entity Framework Core 8
- SQLite
- Swagger / OpenAPI

## Features
- Vehicle fleet management (trucks, vans)
- Waste collection route planning and tracking
- Collection point management with GPS coordinates
- Real-time status updates (Planned, InProgress, Completed)
- Waste type categorization (Recycling, Organic, General)

## Endpoints

### Vehicles
- GET /api/vehicles
- GET /api/vehicles/{id}
- GET /api/vehicles/status/{status}
- POST /api/vehicles
- PUT /api/vehicles/{id}
- PUT /api/vehicles/{id}/status
- DELETE /api/vehicles/{id}

### Routes
- GET /api/routes
- GET /api/routes/{id}
- GET /api/routes/status/{status}
- POST /api/routes
- PUT /api/routes/{id}/status
- DELETE /api/routes/{id}

### Collection Points
- GET /api/collectionpoints
- GET /api/collectionpoints/{id}
- GET /api/collectionpoints/wastetype/{type}
- GET /api/collectionpoints/status/{status}
- POST /api/collectionpoints
- PUT /api/collectionpoints/{id}/status
- DELETE /api/collectionpoints/{id}

## Run Locally
dotnet run
Navigate to http://localhost:5230/swagger
