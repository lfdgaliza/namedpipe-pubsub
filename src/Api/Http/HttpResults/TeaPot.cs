using Microsoft.AspNetCore.Http.Metadata;
using System.Reflection;

namespace Api.Http.HttpResults;

public class TeaPot : IResult, IEndpointMetadataProvider, IStatusCodeHttpResult
{
    public int? StatusCode => StatusCodes.Status418ImATeapot;

    public static void PopulateMetadata(MethodInfo method, EndpointBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(method);
        ArgumentNullException.ThrowIfNull(builder);

        builder.Metadata.Add(new ProducesResponseTypeMetadata(StatusCodes.Status418ImATeapot, typeof(void)));
    }

    public Task ExecuteAsync(HttpContext httpContext)
    {
        ArgumentNullException.ThrowIfNull(httpContext);
        ArgumentNullException.ThrowIfNull(StatusCode);

        httpContext.Response.StatusCode = StatusCode.Value;

        return Task.CompletedTask;
    }
}