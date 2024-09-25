using Application.Interfaces;
using Core;
using Core.DTO;
using Core.Entities;


namespace Application.Service
{
    public class WareHouseService : IWareHouse<ProductStorage, WareHouseDTO>
    {
        private readonly IRepository<ProductStorage> _storageRepository;

        public WareHouseService(IRepository<ProductStorage> ProductStorage)
        {
            _storageRepository = ProductStorage;
        }

        public async Task<ProductStorage> Create(WareHouseDTO wareHouseDTO)
        {
            var productStorage = new ProductStorage
            {
                Id = Guid.NewGuid(),
                Amount = 0,
                Product = wareHouseDTO.Product,
            };
            await _storageRepository.Create(productStorage, CancellationToken.None); 
            return productStorage;
        }
        public async Task <ProductStorage> Update (Guid Id,WareHouseDTO wareHouseDTO)
        {
            var productStorage = await _storageRepository.GetByIdAsync(Id);
            if (productStorage == null) 
            {
                throw new Exception("ProductInStorage not found");
            }
            productStorage.Amount = wareHouseDTO.Amount;
            productStorage.Product = wareHouseDTO.Product;

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
        public async Task<ProductStorage> AddProduct(WareHouseDTO wareHouseDTO, int amount)
        {
            var productStorage = await _storageRepository.GetByIdAsync(wareHouseDTO.Id);
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
