using PublishSubscribe.IO.Api.UseCases.People.Add;
using PublishSubscribe.IO.Api.UseCases.People.Get;

namespace Microsoft.AspNetCore.Routing;

public static class PersonEndpoints
{
    public static IEndpointRouteBuilder RegisterPersonEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var group = endpointRouteBuilder
            .MapGroup("/person")
            .WithTags("Person");

        group
            .RegisterGetPersonEndpoint()
            .RegisterAddPersonEndpoint();

        return endpointRouteBuilder;
    }
}
