using Application.Interfaces;
using Core;
using Core.DTO;
using Core.Entities;


namespace Application.Service
{
    public class StorageService : IStorageProduct<ProductStorage, ProductStorageDTO>
    {
        private readonly IRepository<ProductStorage> _storageRepository;
        public StorageService(IRepository<ProductStorage> ProductStorage)
        {
            _storageRepository = ProductStorage;
        }

        public async Task<ProductStorage> Create(ProductStorageDTO ProductStorageDTO)
        {
            var productStorage = new ProductStorage
            {
                Id = Guid.NewGuid(),
                Amount = 0,
                Product = ProductStorageDTO.Product,
            };
            await _storageRepository.Create(productStorage, CancellationToken.None); 
            return productStorage;
        }
        public async Task <ProductStorage> Update (Guid Id,ProductStorageDTO ProductStorageDTO)
        {
            var productStorage = await _storageRepository.GetByIdAsync(Id);
            if (productStorage == null) 
            {
                throw new Exception("ProductInStorage not found");
            }
            productStorage.Amount = ProductStorageDTO.Amount;
            productStorage.Product = ProductStorageDTO.Product;

            await _storageRepository.Update(productStorage, CancellationToken.None);
            return productStorage;
        }


        public async Task<ProductStorage> Delete(Guid Id)
        {
            var productStorage = await _storageRepository.GetByIdAsync(Id);
            if (productStorage == null)
            {
                throw new Exception("ProductInStorage not found");
            }
            await _storageRepository.Delete(productStorage, CancellationToken.None);
            return productStorage;
        }
        public async Task<ProductStorage> AddProduct(ProductStorageDTO ProductStorageDTO, int amount)
        {
            var productStorage = await _storageRepository.GetByIdAsync(ProductStorageDTO.Id);
            if (productStorage == null)
            {
                throw new Exception("Null");
            }
            productStorage.Amount += amount;
            await _storageRepository.Update(productStorage, CancellationToken.None);
            return productStorage;

        }



            
    }
}
