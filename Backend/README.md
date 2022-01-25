## Dependencies 
1. [.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. [Docker](https://www.docker.com/products/personal)
3. [DynamicExpressions.NET](https://www.nuget.org/packages/DynamicExpressions.NET/1.0.0)

## Notes
1. The API allows CORS from localhost:8080 and connects to the databse at localhost:27017 . If you want change the ports, make sure to change the values in program.cs and appsettings.json
2. The API uses DynamicExpressions.NET in the GetFilteredDestinations method to dynamically choose the month to filter on


## TO DO
1. Change all methods to async
2. Add unit testing
