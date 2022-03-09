using Movie.Data;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
