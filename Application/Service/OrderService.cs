using Core;
using Core.DTO;
using Core.Entities;


namespace Application.Service
{
    public class OrderService : IApplicationService<Cart, CartDTO>
    {
        private readonly IRepository<Cart> _orderRepository;
        public OrderService(IRepository<Cart> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Cart> Create(CartDTO cartDTO)
        {
            var cart = new Cart();
            {
                cart.Id = cartDTO.Id;
                cart.User = cartDTO.User;
                cart.Products = cartDTO.Products;
            };
            await _orderRepository.Create(cart,CancellationToken.None); 
            return cart;
        }

        public async Task <Cart> Update(Guid Id,CartDTO cartDTO)
        {
            var cart = await _orderRepository.GetByIdAsync(Id, CancellationToken.None);
            if (cart == null)
            {
                throw new Exception("Cart not Found");
            }
            
            cart.User = cartDTO.User;
            cart.Products = cartDTO.Products;
            cart.TotalPrice = cartDTO.TotalPrice;
            await _orderRepository.Update(cart, CancellationToken.None);
            return cart;

        }

        public async Task<Cart> Delete(Guid Id)
        {
            var cart = await _orderRepository.GetByIdAsync(Id, CancellationToken.None);
            if(cart == null)
            {
                throw new Exception("Cart not found");
            }
            await _orderRepository.Delete(cart,CancellationToken.None);
            return cart;
        }

            


    }
}
