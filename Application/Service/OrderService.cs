using Application.Interfaces;
using Core;
using Core.DTO;
using Core.Entities;


namespace Application.Service
{
    public class OrderService : IOrder<Cart, OrderDTO>
    {
        private readonly IRepository<Cart> _orderRepository;
        public OrderService(IRepository<Cart> OrderRepository)
        { 
            _orderRepository = OrderRepository;
        
        }

        public async Task<Cart> Create(OrderDTO orderDTO)
        {
            var cart = new Cart
        }

    }
}
