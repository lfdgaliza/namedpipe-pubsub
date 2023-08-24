using MediatR;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;

namespace PublishSubscribe.Application.UseCases.Persons.Get;

public sealed class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, Unit>
{
    private readonly IFindPerson _findPerson;

    public GetPersonQueryHandler(IFindPerson findPerson)
    {
        _findPerson = findPerson;
    }

    public Task<Unit> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = _findPerson.Execute(request.Id);

        if (person is null)
        {
            request.OutputPort.NotFound();
            return Unit.Task;
        }

        if (person!.Name == "Elizabeth II")
        {
            request.OutputPort.TeaPot();
            return Unit.Task;
        }

        request.OutputPort.Found(person);
        return Unit.Task;
    }
}

public interface IGetPersonQueryOutputPort
{
    void Found(Person person);
    void NotFound();
    void TeaPot();
}