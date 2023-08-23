using MediatR;
using PublishSubscribe.Domain;
using PublishSubscribe.Domain.Repositories;

namespace PublishSubscribe.Application.UseCases.Persons.Add;

public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Person>
{
    private readonly IAddPerson _addPerson;
    private readonly IMediator _mediator;

    public AddPersonCommandHandler(IMediator mediator, IAddPerson addPerson)
    {
        _mediator = mediator;
        _addPerson = addPerson;
    }

    public async Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person(request.Name);
        _addPerson.Execute(person);
        var notification = new PersonAddedNotification(person);
        await _mediator.Publish(notification, cancellationToken);
        return person;
    }
}

public sealed record PersonAddedNotification(Person Person) : INotification;