namespace Application.Interfaces
{
    public interface IService<TEntity, TDto>
    {
        Task<TEntity> Create(TDto dto);
        Task<TEntity> Update(Guid Id, TDto dto);
        Task<TEntity> Delete(Guid Id);

    }
}
