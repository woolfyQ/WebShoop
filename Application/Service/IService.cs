using Core.DTO;
using Core.Entities;

namespace Application.Service
{
    public interface IApplicationService
    {
        Task <Product> Create(ProductDTO productDTO);
        Task <Product> Update (Guid Id, ProductDTO productDTO);  
        Task <Product> Delete (Guid Id);  
    }
}
