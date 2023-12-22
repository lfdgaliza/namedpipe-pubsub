using MediatR;

namespace PublishSubscribe.Application.UseCases.People.Get;

public sealed record GetPersonQuery(Guid Id) : IRequest<IGetPersonQueryOutputPort>;