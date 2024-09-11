using Core;
using Core.DTO;

namespace Application.Service
{
    public class OrderService : IApplicationService<OrderDTO, orderDTO>
    {
        private readonly IRepository<Order> _orderRepository;
        public OrderService(IRepository<OrderDTO> orderRepository)
        {
            _orderRepository = orderRepository;
        }
            


    }
}
