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
    public class ExecutivesController : ControllerBase
    {
        private readonly IExecutiveRepository _executiveRepository;

        public ExecutivesController(
            IExecutiveRepository executiveRepository
            )
        {
            _executiveRepository = executiveRepository;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] ExecutiveBllModel executive)
        {
            try
            {
                return Ok(_executiveRepository.CreateOrUpdate(executive));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}