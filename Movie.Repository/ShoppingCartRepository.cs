using Movie.Data;
using Movie.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movie.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _dataContext;

        public ShoppingCartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
