using Core.DTO;

namespace WebShop.API.Controller
{
    public interface IController
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task<ProductDTO> GetByIdAsync(Guid Id);
        Task<ProductDTO> Create(ProductDTO productDTO);
        Task<ProductDTO> Update(Guid Id, ProductDTO productDTO);
        Task<ProductDTO> DeleteByIdAsync(Guid id);
            
    }
}
