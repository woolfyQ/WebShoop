namespace Application.Interfaces
{
    public interface IWareHouse<TEntity, TDto>
    {
        Task<TEntity> Create(TDto Tdto);
        Task<TEntity> Update(Guid Id, TDto Tdto);
        Task<TEntity> Delete(Guid Id);
        Task<TEntity> AddProduct(TDto Tdto, int Amount);


    }
}
