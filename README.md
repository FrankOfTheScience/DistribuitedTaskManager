# DistribuitedTaskManager

DistribuitedTaskManager is a distributed task management system built with ASP.NET Core. The application demonstrates a variety of distributed system concepts and design patterns, including SignalR for real-time communication, JWT-based authentication, Redis caching for task data, and more.

## Features

- **Task Management**: Create, read, update, and delete tasks.
- **Real-Time Notifications**: Using SignalR to notify users of changes in task assignments.
- **Distributed Cache**: Redis is used to cache task data to improve performance.
- **Authentication & Authorization**: JWT-based authentication for securing API access.
- **Swagger Integration**: Provides a simple API documentation for interacting with the backend.

## Technologies

- **Backend**: ASP.NET Core 6.0
- **SignalR**: Real-time notifications and communication
- **JWT Authentication**: Secure access to the API using JWT tokens
- **Redis**: Caching task data for optimized performance
- **Entity Framework Core**: ORM for interacting with SQL Server
- **Swagger**: API documentation for easy testing and interaction

## Requirements

- .NET 6.0 SDK or later
- SQL Server (or a compatible database provider)
- Redis (for caching)
- Visual Studio or another preferred IDE

## Setup

### 1. Clone the repository

```bash
git clone https://github.com/FrankOfTheScience/DistribuitedTaskManager.git
cd DistribuitedTaskManager
```

### 2. Configure the database
Ensure you have a SQL Server instance available and configure your connection string in appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "<YOUR-DB-CONNECTION-STRING>"
}
```

### 3. Configure Redis (Optional for caching)
If you want to enable Redis caching, make sure you have Redis running locally or remotely. You can configure the Redis connection string in Program.cs:

```csharp
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "<YOUR-REDIS-CACHE-CONNECTION-STRING>";
});
```

### 4. Run the application
Build and run the application using Visual Studio or via the command line:

```bash
dotnet build
dotnet run
```
The application will start on https://localhost:5001. You can interact with the API using Swagger UI at /swagger.

## API Endpoints

`GET /api/task`
Retrieve a list of all tasks.

`GET /api/task?id={id}`
Retrieve a task by its ID from the cache or database if not cached.

`POST /api/task`
Create a new task. The task details should be passed in the request body.

## Authentication
To access secured endpoints, you'll need a valid JWT token. You can obtain this by logging in through the authentication endpoint (to be implemented if necessary).

## Future Enhancements
- Implement additional error handling and validations.
- Implement additional action for Task API.
- Create a real OAuth2.0 integration for more advanced authentication.
- Create an UI using Blazor or a frontend framework like React.
- Implement a Gateway with Ocelot.

## Contributing
This was not meant to be a real project, just an exercise but if you'd like to contribute, please feel free to fork the repository and submit pull requests.
Maybe it could become more than a mere exercise.

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/FrankOfTheScience/DistribuitedTaskManager/blob/master/LICENSE.txt) file for details.
