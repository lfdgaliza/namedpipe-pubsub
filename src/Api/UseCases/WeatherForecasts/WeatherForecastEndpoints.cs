using PublishSubscribe.IO.Api.UseCases.WeatherForecasts.Get;

namespace Microsoft.AspNetCore.Routing;

public static class WeatherForecastEndpoints
{
    public static IEndpointRouteBuilder RegisterWeatherForecastEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var group = endpointRouteBuilder
            .MapGroup("/weatherforecast")
            .WithTags("Weather forecast");

        group
            .RegisterGetWeatherForecastEndpoint();

        return endpointRouteBuilder;
    }
}
