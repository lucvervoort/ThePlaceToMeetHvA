using Microsoft.AspNetCore.SignalR;

namespace ThePlaceToMeet.WebApi.Hubs
{
    public class ChatHub : Hub
    {
        // we can use the dependency injector: see ctor
        private readonly IConfiguration _configuration;
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(IConfiguration configuration, ILogger<ChatHub> logger)
        {
            _configuration = configuration;
            _logger?.LogInformation("Starting ChatHub...");
        }

        public override Task OnConnectedAsync()
        {
            // wait until login to add the connection to the table 
            _logger?.LogInformation("Connection request received on ChatHub...");
            // Don't forget to call the base class
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _logger?.LogInformation("Disconnection request received on ChatHub...");
            // Don't forget to call the base class
            await base.OnDisconnectedAsync(exception);
        }

        public async Task<string> ProcessChatMessage(string user, string message)
        {
            _logger?.LogDebug($"ChatHub received message \"{message}\" from {user}");
            await Clients.All.SendAsync("ProcessChatMessage", user, message);
            return "OK";
        }
    }
}
