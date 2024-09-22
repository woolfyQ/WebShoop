using Core.DTO;

namespace Application.Interfaces
{
    public interface IOrder <TEntity, Tdto>
    {
        Task<TEntity> Create (OrderDTO orderDTO);
        Task<TEntity> AddProduct (Guid Id, ProductDTO productDTO, int Amount);
        Task<TEntity> Delete (Guid Id);


    }
}
