namespace PublishSubscribe.Domain;

public class EntityBase
{
    protected EntityBase()
    {
    }

    public Guid Id { get; } = Guid.NewGuid();
}