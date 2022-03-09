using System;
using System.Collections.Generic;
using System.Text;
using Movie.Repository.Interfaces;
using Movie.Services.Interfaces;

namespace Movie.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartServices(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
    }
}
