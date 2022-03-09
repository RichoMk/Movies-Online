using Microsoft.AspNetCore.Mvc;
using Movie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesOnline.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
