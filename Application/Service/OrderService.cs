using Application.Interfaces;
using Core;
using Core.DTO;
using Core.Entities;


namespace Application.Service
{
    public class OrderService : IOrder<Cart, ProductCartDTO>
    {
        private readonly IRepository<Cart> _cartRepository; // Репозиторий для Cart
        //private readonly IRepository<ProductCart> _productCartRepository; // Репозиторий для ProductCart

        public OrderService(IRepository<Cart> cartRepository, IRepository<ProductCart> productCartRepository)
        {
            _cartRepository = cartRepository; 
        }

        public async Task<Cart> Create(ProductCartDTO productCartDTO)
        {
            var cart = await _cartRepository.GetByIdAsync(productCartDTO.Cart.Id);
            if (cart == null)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    User = productCartDTO.User,
                    TotalPrice = 0,
                    Products = []
                };
                var productCart = new ProductCart
                {
                    Id = Guid.NewGuid(),
                    Amount = productCartDTO.Amount,
                    Product = productCartDTO.Product
                };
                cart.Products.Add(productCart);
                cart.TotalPrice += productCart.Product.Price * productCartDTO.Amount;
                await _cartRepository.Create(cart, CancellationToken.None);

            }
            else
            {
                var productCart = new ProductCart
                {
                    Id = Guid.NewGuid(),
                    Amount = productCartDTO.Amount,
                    Product = productCartDTO.Product

                };
                cart.Products.Add(productCart);
                cart.TotalPrice += productCart.Product.Price * productCart.Amount;
                await _cartRepository.Create(cart, CancellationToken.None);

            }
            return cart;

        }
        public async Task<Cart> AddProduct(ProductCartDTO productCartDTO)
        {
            var cart = await _cartRepository.GetByIdAsync(productCartDTO.Id) ?? throw new Exception("Cart not found");
            var existingProduct = cart.Products.FirstOrDefault(p => p.Product.Id == productCartDTO.Product.Id);
            if (existingProduct != null)
            {
                existingProduct.Amount += productCartDTO.Amount;
            }
            else
            {
                var newProductCart = new ProductCart
                {
                    Id = Guid.NewGuid(),
                    Amount = productCartDTO.Amount,
                    Product = productCartDTO.Product

                };
                cart.Products.Add(newProductCart);
            }

            cart.TotalPrice += productCartDTO.Product.Price * productCartDTO.Amount;
            await _cartRepository.Update(cart, CancellationToken.None);
            return cart;
        }


        public async Task<Cart> Delete(Guid Id,ProductCartDTO productCartDTO)
        {
            var cart = await _cartRepository.GetByIdAsync(productCartDTO.Id) ?? throw new Exception("Cart not found");
            await _cartRepository.Delete(cart,CancellationToken.None);
            return cart;
        }
    }
}
