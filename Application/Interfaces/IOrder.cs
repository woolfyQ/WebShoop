using Core.DTO;

namespace Application.Interfaces
{
    public interface IOrder <TEntity, Tdto>
    {
        Task<TEntity> Create (ProductCartDTO productCartDTO);
        Task<TEntity> AddProduct (ProductCartDTO productCartDTO);
        Task<TEntity> Delete (Guid Id, ProductCartDTO productCartDTO);




    }
}
