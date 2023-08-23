namespace PublishSubscribe.Domain.Aggregates.PersonAggregate;

public sealed class Person : EntityBase, IAggregateRoot
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}