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
    public class AlertController : ControllerBase
    {
        private readonly IAlertsRepository _alertRepository;

        public AlertController(
            IAlertsRepository alertsRepository
            )
        {
            _alertRepository = alertsRepository;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] AlertBllModel alert)
        {
            var res = _alertRepository.CreateOrUpdate(alert);
            return Ok(res);
        }
    }
}