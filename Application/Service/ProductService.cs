﻿using Core.Entities;
using Core.DTO;
using Core;
using Application.Interfaces;
using System.Runtime.CompilerServices;


namespace Application.Service
{

    public class ProductService : IApplicationService<Product, ProductDTO>
    {
        
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
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

            await _productRepository.Create(product, CancellationToken.None);
            return product;
            
        }
        public async Task<Product> Update(Guid Id, ProductDTO productDTO)
        {
            var product = await _productRepository.GetByIdAsync(Id);
            {
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                
                product.Description = productDTO.Description;
                product.Name = productDTO.Name;
                product.Img = productDTO.Img;
                product.Price = productDTO.Price;
                product.Specs = productDTO.Specs;
                
            }
            await _productRepository.Update(product, CancellationToken.None);
            return product;
        }
        public async Task<Product> Delete(Guid Id)
        {

            var product = await _productRepository.GetByIdAsync(Id);

            if (product == null)
            {
                throw new Exception("Product nof found");
            }

            await _productRepository.Delete(product, CancellationToken.None);
            return product;
        }
    }
}

   





