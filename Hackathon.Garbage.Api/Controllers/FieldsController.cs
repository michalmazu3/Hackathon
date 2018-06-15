using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackathon.Garbage.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Garbage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<List<FieldEntity>> GetAll()
        {
            var fields = new List<FieldEntity>();
            fields.Add(new FieldEntity {
                Cordinates = {
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.8) },
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.84) },
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.88) },
                    new CordinatesEntity { Latitude = new decimal(50.4), Longitude = new decimal(21.9) },
                },
                Name = "działka 1",
                });
            fields.Add(new FieldEntity
            {
                Cordinates ={
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.8) },
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.84) },
                    new CordinatesEntity { Latitude = new decimal(50.2), Longitude = new decimal(21.88) },
                    new CordinatesEntity { Latitude = new decimal(50.4), Longitude = new decimal(21.9) },
                },
                Name = "działka 1"
            });
            fields.ForEach(x => {
                x.Orders.Add(new OrderEntity(x));
            });
            return Ok(fields);
        }
    }
}