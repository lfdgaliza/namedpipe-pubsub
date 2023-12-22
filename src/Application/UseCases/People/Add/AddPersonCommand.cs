using MediatR;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;

namespace PublishSubscribe.Application.UseCases.People.Add;

public sealed record AddPersonCommand(string Name) : IRequest<Person>;