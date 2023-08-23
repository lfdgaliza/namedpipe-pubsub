namespace PublishSubscribe.Domain.Repositories;

public interface IFindEntity<TEntity> where TEntity : EntityBase, IAggregateRoot
{
    TEntity? Execute(Guid id);
}