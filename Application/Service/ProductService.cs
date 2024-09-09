using Microsoft.EntityFrameworkCore;
using Core.Entities;
using WebShoop.Data;
using Core.DTO;
using Core;
using Infrastructure;

namespace Application.Service
{

    public class ProductService : IApplicationService
    {
        
        private readonly IRepository<Product> _ProductRepository;

        public ProductService(IRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<Product> Create(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Description = productDTO.Description,
                Name = productDTO.Name,
                Img = productDTO.Img,
                Price = productDTO.Price,
                Specs = productDTO.Specs,
            };

            await _ProductRepository.Create(product, CancellationToken.None);
            return product;
            
        }
        public async Task<Product> Update(Guid Id, ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = Id,
                Description = productDTO.Description,
                Name = productDTO.Name,
                Img = productDTO.Img,
                Price = productDTO.Price,
                Specs = productDTO.Specs,
            };
            await _ProductRepository.Update(product, CancellationToken.None);
            return product;
        }
        public async Task<Product> Delete(Guid Id)
        {

            var product = await _ProductRepository.GetByIdAsync(Id, CancellationToken.None);

            if (product == null)
            {
                throw new Exception("Product nof found");
            }

            await _ProductRepository.Delete(product, CancellationToken.None);
            return product;
        }
    }
}

   





