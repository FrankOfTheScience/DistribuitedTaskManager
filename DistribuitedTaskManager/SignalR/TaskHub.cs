using Microsoft.AspNetCore.SignalR;

namespace DistribuitedTaskManager.SignalR;

public class TaskHub : Hub
{
    public async Task NotifyTaskAssigned(string taskName)
        => await Clients.All.SendAsync("ReceiveTaskAssigned", taskName);

    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }
}    
