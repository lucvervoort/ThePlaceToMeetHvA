using System;
using System.Threading.Tasks;
using MVVM;
using Microsoft.AspNetCore.SignalR.Client;

namespace ThePlaceToMeet.Wpf.App
{
    public class ChatEventArgs: EventArgs
    {
        public string User { get; set; } = "?";
        public string Message { get; set; } = "";
    }

    public class SignalRClient : ViewModelBase
    {
        #region Singleton
        private static SignalRClient? _instance;
        public static SignalRClient Instance => _instance ??= new SignalRClient();
        #endregion

        // use the url of the Web API and add the hub name of SignalR:
        private static readonly string _endpointAddress = "https://localhost:7045/chathub";
        private HubConnection? _connection;

        private bool _isConnected = false;
        public bool IsConnected
        {
            get => _isConnected;
            private set
            {
                _isConnected = value;
                RaisePropertyChanged(nameof(IsConnected));
            }
        }

        public event EventHandler<ChatEventArgs>? ChatMessageReceived;

        private SignalRClient()
        {
        }

        public async void Initialize()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(_endpointAddress /*, options =>
                { options.SkipNegotiation = true; options.Transports = HttpTransportType.WebSockets; } */ )
                // Autoconnect was previously not available:
                .WithAutomaticReconnect()
                .Build();

            _connection.Reconnecting += error =>
            {
                // Notify users the connection was lost and the client is reconnecting.
                // Start queuing or dropping messages.

                System.Diagnostics.Debug.WriteLine($"SignalRClient reconnecting... ({error})");
                return Task.CompletedTask;
            };

            _connection.Reconnected += connectionId =>
            {
                // Notify users the connection was reestablished.
                // Start dequeuing messages queued while reconnecting if any.

                System.Diagnostics.Debug.WriteLine($"SignalRClient reconnected ({connectionId})");
                return Task.CompletedTask;
            };

            _connection.Closed += async (error) =>
            {
                System.Diagnostics.Debug.WriteLine($"SignalRClient closed - restarting... ({error})");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };

            System.Diagnostics.Debug.WriteLine($"SignalRClient starting...");

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            System.Diagnostics.Debug.WriteLine(_connection.State == HubConnectionState.Connected ? "Connected" : "Not connected");

            //allow unauth

            _connection.On<string, string>("ProcessChatMessage", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                System.Diagnostics.Debug.WriteLine(newMessage);
                ChatMessageReceived?.Invoke(this, new ChatEventArgs { User = user, Message = message });
            });
        }

        public async void SendMessage(string user, string message)
        {
            if (_connection == null || _connection.State != HubConnectionState.Connected) 
            {
                System.Diagnostics.Debug.WriteLine("Cannot send to server");
                return; 
            }

            await _connection.SendAsync("ProcessChatMessage", user, message);
        }
    }
}
