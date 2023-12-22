using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublishSubscribe.Application.UseCases.People.Add;

namespace PublishSubscribe.IO.Api.UseCases.People.Add;

public static class AddPersonEndpoint
{
    public static RouteGroupBuilder RegisterAddPersonEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapPost(string.Empty, async (
            [FromServices] IMediator mediator,
            [FromBody] string name
        ) =>
        {
            var person = await mediator.Send(new AddPersonCommand(name));
            return TypedResults.Created(person.Id.ToString(), person);
        });

        return routeGroupBuilder;
    }
}
