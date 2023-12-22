using MediatR;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;

namespace PublishSubscribe.Application.UseCases.People.Get;

public sealed class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, IGetPersonQueryOutputPort>
{
    private readonly IFindPerson _findPerson;
    private readonly IGetPersonQueryOutputPort _getPersonQueryOutputPort;

    public GetPersonQueryHandler(IFindPerson findPerson, IGetPersonQueryOutputPort getPersonQueryOutputPort)
    {
        _findPerson = findPerson;
        _getPersonQueryOutputPort = getPersonQueryOutputPort;
    }

    public Task<IGetPersonQueryOutputPort> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = _findPerson.Execute(request.Id);

        if (person is null)
        {
            _getPersonQueryOutputPort.NotFound();
        }
        else if (person.Name == "Elizabeth II")
        {
            _getPersonQueryOutputPort.TeaPot();
        }
        else
        {
            _getPersonQueryOutputPort.Found(person);
        }

        return Task.FromResult(_getPersonQueryOutputPort);
    }
}

public interface IGetPersonQueryOutputPort
{
    void Found(Person person);
    void NotFound();
    void TeaPot();
}