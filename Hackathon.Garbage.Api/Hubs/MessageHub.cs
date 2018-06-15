using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Garbage.Dal.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message, int id)
        {
            await Clients.All.SendAsync("NewProblemNotification", message,id );
        }
    }
}
