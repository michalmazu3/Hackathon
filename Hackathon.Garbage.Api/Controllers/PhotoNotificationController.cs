using System;
using System.Threading.Tasks;
using Hackathon.Garbage.Dal.Hubs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Garbage.Dal.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoNotificationController : ControllerBase
    {/*
        private readonly GarbageDbContext garbageDbContext;
        private readonly IHubContext<MessageHub> hub;

        public PhotoNotificationController(GarbageDbContext garbageDbContext, IHubContext<MessageHub> hub)
        {
            this.garbageDbContext = garbageDbContext;
            this.hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
            {
            try
            {

                var list =await garbageDbContext.ProblemNotifications.ToListAsync();
                return Ok(list);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {

                var list = await garbageDbContext.ProblemNotifications.FirstOrDefaultAsync(f => f.Id == id);
                return Ok(list);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ProblemNotification problemNotification)
        {
            try
            {

                var inserted = await garbageDbContext.ProblemNotifications.AddAsync(problemNotification);
                await garbageDbContext.SaveChangesAsync();
                await hub.Clients.All.SendAsync("NewProblemNotification", "add new problem notifiaction", inserted.Entity.Id);
                return Ok(inserted);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }*/
    }
}