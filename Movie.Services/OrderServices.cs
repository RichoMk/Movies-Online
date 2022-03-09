using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Services
{
  public  class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
    }
}
