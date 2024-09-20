namespace Core
{
    public record Id(Guid Value);
    public interface IEntity
    {
        Guid Id { get; set; } 
    }

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task Create (IEntity entity, CancellationToken cancellationToken);
        Task Create (IEnumerable <IEntity> entity, CancellationToken cancellationToken);
        Task Update (IEntity entity, CancellationToken cancellationToken);  
        Task Update(IEnumerable <IEntity> entities, CancellationToken cancellationToken);   
        Task Delete (IEntity entity, CancellationToken cancellationToken);
        Task Delete(IEnumerable<IEntity> entity, CancellationToken cancellationToken);
        Task <TEntity> GetByIdAsync(Guid Id);
    }
        

}
