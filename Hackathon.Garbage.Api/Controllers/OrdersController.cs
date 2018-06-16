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



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _orderRepository.GetAll();
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] OrderBllModel order)
        {
            try
            {
                var res = _orderRepository.CreateOrUpdate(order);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Photos")]
        public IActionResult PostPhoto([FromBody] Byte[] photo, int orderId)
        {
            return Ok();
        }   

        [HttpGet("Photos")]
        public IActionResult GetPhotos(int orderId,int index)
        {
            var photo = _orderRepository.GetPhotos(orderId,index);
            
            return File(photo, "image/jpeg");

        }
    }
}