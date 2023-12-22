using Api.Http.HttpResults;
using Api.HttpResults;
using Microsoft.AspNetCore.Http.HttpResults;
using PublishSubscribe.Application.UseCases.People.Get;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;
using System.Diagnostics.CodeAnalysis;

namespace PublishSubscribe.IO.Api.UseCases.People.Get;

public class GetPersonEndpointPresenter : IGetPersonQueryOutputPort
{
    [NotNull]
    public Results<Ok<Person>, NotFound, TeaPot>? Result { get; private set; }

    public void Found(Person person)
        => Result = TypedResults.Ok(person);

    public void NotFound()
        => Result = TypedResults.NotFound();

    public void TeaPot()
        => Result = CustomTypedResults.TeaPot();
}
