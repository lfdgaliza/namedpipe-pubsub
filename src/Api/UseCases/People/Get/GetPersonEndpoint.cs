using Api.Http.HttpResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PublishSubscribe.Application.UseCases.People.Get;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;

namespace PublishSubscribe.IO.Api.UseCases.People.Get;

public static class GetPersonEndpoint
{
    public static RouteGroupBuilder RegisterGetPersonEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        routeGroupBuilder.MapGet(string.Empty, async Task<Results<Ok<Person>, NotFound, TeaPot>> (
            [FromServices] IMediator mediator,
            [FromQuery] Guid id
        ) =>
        {
            var outputPort = await mediator.Send(new GetPersonQuery(id));
            return ((GetPersonEndpointPresenter)outputPort).Result;
        });

        return routeGroupBuilder;
    }
}
