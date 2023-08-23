using PublishSubscribe.Domain.Repositories;

namespace PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;

public interface IFindPerson : IFindEntity<Person>
{
}