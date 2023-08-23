namespace PublishSubscribe.Domain;

public sealed class Person : EntityBase, IAggregateRoot
{
    public Person(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}