
using Microservices.Hubs.Providers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Microservices.Hubs.Base
{
    public abstract class BaseHub<T> : Hub<T> where T : class
    {

        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User?.GetId());
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User?.GetId());
            return base.OnDisconnectedAsync(exception);
        }
    }
}
