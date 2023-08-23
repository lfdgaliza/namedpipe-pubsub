namespace PublishSubscribe.Domain.Repositories;

public interface IDeleteEntity<TEntity> where TEntity : EntityBase, IAggregateRoot
{
    void Execute(TEntity entity);
}