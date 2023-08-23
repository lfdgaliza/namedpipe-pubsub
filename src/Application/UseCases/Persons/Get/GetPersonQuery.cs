using MediatR;

namespace PublishSubscribe.Application.UseCases.Persons.Get;

public sealed record GetPersonQuery(Guid Id, IGetPersonQueryOutputPort OutputPort) : IRequest<Unit>;