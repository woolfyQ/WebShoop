namespace Application.Interfaces
{
    public interface IStorageProduct<TEntity, TDto>
    {
        Task<TEntity> Create(TDto Tdto);
        Task<TEntity> Update(Guid Id, TDto Tdto);
        Task<TEntity> Delete(Guid Id);
        Task<TEntity> AddProduct(TDto Tdto, int Amount);


    }
}
