using Application.Interfaces;
using Core;
using Core.DTO;
using Core.Entities;
using System.Runtime.CompilerServices;


namespace Application.Service
{
    public class OrderService : IOrder<Order, OrderDTO>
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Create(OrderDTO orderDTO)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Cart = orderDTO.Cart,
                User = orderDTO.User,
                DateTime = DateTime.Now,
                Products = orderDTO.Products,
                TotalPrice = orderDTO.TotalPrice
            };
            await _orderRepository.Create(order, CancellationToken.None);
            return order;
        }
        public async Task<Order> AddProduct(OrderDTO orderDTO)
        {
            var order = await _orderRepository.GetByIdAsync(orderDTO.Id);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            // Проверяем, есть ли продукты в корзине
            if (orderDTO.Cart?.Products != null && orderDTO.Cart.Products.Any())
            {
                foreach (var item in orderDTO.Cart.Products)
                {
                    // Создаем новый ProductCart для добавления в заказ
                    var productCart = new ProductCart
                    {
                        Product = item.Product,
                        Amount = item.Amount
                    };

                    // Добавляем productCart в заказ
                    order.Products.Add(productCart);
                    order.TotalPrice += item.Product.Price * item.Amount; // Учитываем количество
                }

                await _orderRepository.Update(order, CancellationToken.None);
            }
            return order;
        }
        public async Task<Order> Delete(Guid Id, OrderDTO orderDTO)
        {
            var order = await _orderRepository.GetByIdAsync(orderDTO.Id);
            if(order == null)
            {
                throw new Exception("order not found");
            }
            await _orderRepository.Delete(order, CancellationToken.None);
            return order;


        }
        public async Task<Order> GetByIdAsync(Guid Id)
        {
            var order = await _orderRepository.GetByIdAsync(Id);
            return order;


        }





    }
}