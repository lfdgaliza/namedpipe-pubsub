using PublishSubscribe.Domain;
using PublishSubscribe.Domain.Repositories;

namespace InMemoryRepository;

public class PersonRepository : RepositoryBase<Person>, IAddPerson, IFindPerson
{
}