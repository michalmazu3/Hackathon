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
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingController(
            IRatingRepository ratingRepository
            )
        {
            _ratingRepository = ratingRepository;
        }

        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] RatingBllModel rating)
        {
            var res = _ratingRepository.CreateOrUpdate(rating);
            return Ok(res);
        }
    }
}