namespace Application.Interfaces
{
    public interface IOrder <TEntity, TDto>
    {
        Task<TEntity> Create (TDto dto);
        Task<TEntity> AddProduct (TDto dto );
        Task<TEntity> Delete (Guid Id, TDto dto);
        Task<TEntity> GetByIdAsync (Guid Id);




    }
}
