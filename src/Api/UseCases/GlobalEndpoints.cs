namespace Microsoft.AspNetCore.Routing;

public static class GlobalEndpoints
{
    public static IEndpointRouteBuilder RegisterEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder
            .RegisterWeatherForecastEndpoints()
            .RegisterPersonEndpoints();
    }
}
