using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Garbage.Dal.DbContexts;
using Hackathon.Garbage.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Dal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly FloraDbContext _floraDbContext;

        public DatabaseController(
            FloraDbContext floraDbContext
            )
        {
            _floraDbContext = floraDbContext;
        }

        [HttpGet]
        public IActionResult GenerateDb()
        {
            return Ok(generate());
        }

        private int generate()
        {
            var fields = new List<FieldEntity>();
            var cords = new List<CordinatesEntity>
                {
                    new CordinatesEntity { lat = new decimal(50.865279), lng= new decimal(20.627222) },
                    new CordinatesEntity { lat = new decimal(50.865475), lng= new decimal(20.631170) },
                    new CordinatesEntity { lat = new decimal(50.862400), lng= new decimal(20.630743) },
                    new CordinatesEntity { lat = new decimal(50.862960), lng= new decimal(20.622941) },
                    new CordinatesEntity { lat = new decimal(50.865279), lng= new decimal(20.627222) },
                };
            _floraDbContext.AddRange(cords);
            fields.Add(new FieldEntity
            {
                Cordinates = cords,
                Name = "działka 1",
            });
            cords = new List<CordinatesEntity>
            {
                new CordinatesEntity { lat = new decimal(50.867279), lng = new decimal(20.637222) },
                new CordinatesEntity { lat = new decimal(50.867475), lng = new decimal(20.641170) },
                new CordinatesEntity { lat = new decimal(50.863400), lng = new decimal(20.640743) },
                new CordinatesEntity { lat = new decimal(50.864960), lng = new decimal(20.632941) },
                new CordinatesEntity { lat = new decimal(50.867279), lng = new decimal(20.637222) },
                };
            _floraDbContext.AddRange(cords);
            fields.Add(new FieldEntity
            {
                Cordinates = cords,
                Name = "działka 2"
            });
            fields.ForEach(x =>
            {
                var order = new OrderEntity(x);
                x.Orders.Add(order);
                _floraDbContext.Add(order);
            });
            _floraDbContext.AddRange(fields);
            return _floraDbContext.SaveChanges();
        }
    }
}