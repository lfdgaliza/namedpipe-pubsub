using MediatR;
using PublishSubscribe.Domain;

namespace PublishSubscribe.Application.UseCases.Persons.Add;

public sealed record AddPersonCommand(string Name) : IRequest<Person>;