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
                    new CordinatesEntity { lat = new decimal(50.865279), lng= new decimal(20.627222) },
                    new CordinatesEntity { lat = new decimal(50.865475), lng= new decimal(20.631170) },
                    new CordinatesEntity { lat = new decimal(50.862400), lng= new decimal(20.630743) },
                    new CordinatesEntity { lat = new decimal(50.862960), lng= new decimal(20.622941) },
                  new CordinatesEntity { lat = new decimal(50.865279), lng= new decimal( 20.627222) },

                },
                Name = "działka 1",
                });
            fields.Add(new FieldEntity
            {
                Cordinates ={
                  new CordinatesEntity { lat = new decimal(50.867279), lng= new decimal(20.637222) },
                    new CordinatesEntity { lat = new decimal(50.867475), lng= new decimal(20.641170) },
                    new CordinatesEntity { lat = new decimal(50.863400), lng= new decimal(20.640743) },
                    new CordinatesEntity { lat = new decimal(50.864960), lng= new decimal(20.632941) },
                  new CordinatesEntity { lat = new decimal(50.867279), lng= new decimal( 20.637222) },
                },
                Name = "działka 2"
            });
            fields.ForEach(x => {

                List<ExecutiveEntity> ex = new List<ExecutiveEntity>()
                {
                    new ExecutiveEntity() {Name = "Firma 1"},
                new ExecutiveEntity() { Name = "Firma 2" },
                new ExecutiveEntity() { Name = "Firma 3" }

                };
              
              
                x.Orders.Add(new OrderEntity(x) { Status = OrderStatus.IN_PROGRESS, Executive = new ExecutiveEntity() { Name = "Firma 1" } });
            });
            return Ok(fields);
        }
    }
}