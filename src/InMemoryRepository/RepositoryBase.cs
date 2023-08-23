using PublishSubscribe.Domain;
using PublishSubscribe.Domain.Repositories;

namespace PublishSubscribe.Plugins.InMemoryRepository;

public class RepositoryBase<TEntity> :
    IAddEntity<TEntity>,
    IFindEntity<TEntity>,
    IDeleteEntity<TEntity>
    where TEntity : EntityBase, IAggregateRoot
{
    private static readonly List<TEntity> _entities = new();

    protected RepositoryBase()
    {
    }

    void IAddEntity<TEntity>.Execute(TEntity entity)
    {
        _entities.Add(entity);
    }

    void IDeleteEntity<TEntity>.Execute(TEntity entity)
    {
        _entities.Remove(entity);
    }

    TEntity? IFindEntity<TEntity>.Execute(Guid id)
    {
        return _entities.FirstOrDefault(e => e.Id == id);
    }
}