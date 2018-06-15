using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Garbage.Dal.Models;
using Hackathon.Garbage.Dal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _orderRepository;

        public OrdersController(
            IOrdersRepository ordersRepository
            )
        {
            _orderRepository = ordersRepository;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] OrderBllModel order)
        {
            try
            {
                var res = _orderRepository.CreateOrUpdate(order);
                return Ok(res);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
    }
}