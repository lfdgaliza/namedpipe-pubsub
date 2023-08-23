using PublishSubscribe.Domain.Aggregates.PersonAggregate;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;

namespace PublishSubscribe.Plugins.InMemoryRepository;

public class PersonRepository : RepositoryBase<Person>, IAddPerson, IFindPerson
{
}