using MediatR;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;

namespace PublishSubscribe.Application.UseCases.Persons.Add;

public sealed record AddPersonCommand(string Name) : IRequest<Person>;