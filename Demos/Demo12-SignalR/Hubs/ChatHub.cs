using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo12_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public override async  Task OnConnectedAsync()
        {
            Users.Add();
            await Clients.All.SendAsync("Usuarios Conectados", Users.users);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Users.Remove();
            await Clients.All.SendAsync("Usuarios Conectados", Users.users);
        }

        public async Task EnviarMsg(string user, string msg)
        {
            await Clients.All.SendAsync("ReadAllMessages", user, msg);
        }


    }
    public class Users
    {
        public static int users = 0;

        public static void Add()
        {
            users++;
        }
        public static void Remove()
        {
            users--;
        }
    }
}
