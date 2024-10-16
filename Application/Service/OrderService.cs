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
        //public async Task<Order> AddProducts(OrderDTO orderDTO)
        //{
        //    await _orderRepository


        //}