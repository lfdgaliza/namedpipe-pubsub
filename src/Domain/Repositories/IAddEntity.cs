namespace PublishSubscribe.Domain.Repositories;

public interface IAddEntity<TEntity> where TEntity : EntityBase, IAggregateRoot
{
    void Execute(TEntity entity);
}