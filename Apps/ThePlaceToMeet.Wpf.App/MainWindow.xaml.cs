using System.Windows;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ThePlaceToMeet.Wpf.App.ViewModels;
using System.Windows.Input;
using System.Text;
//using IdentityModel.OidcClient;

namespace ThePlaceToMeet.Wpf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<App>? _logger;
        private readonly IConfiguration _configuration;
        /*
        // IdentityServer
        private readonly OidcClient _client;
        */

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public MainWindow(ILogger<App> logger, IConfiguration configuration /*, OidcClient client*/)
        {
            InitializeComponent();

            var app = Application.Current as ThePlaceToMeet.Wpf.App.App;
            //_logger = app?.Host.Services.GetRequiredService<ILogger<App>>();
            //_configuration = app?.Host.Services.GetRequiredService<IConfiguration>();
            _logger = logger;
            _configuration = configuration;
            //_client = client;
            MainWindowViewModel = new(_logger, _configuration/*, _client*/);
            DataContext = MainWindowViewModel;

            SignalRClient.Instance.ChatMessageReceived += Instance_ChatMessageReceived;
        }

        private void Instance_ChatMessageReceived(object? sender, ChatEventArgs e)
        {
            // Belangrijk voor WPF: alles op de GUI moet afgehandeld worden op de main thread;  dit kan via de Dispatcher!!!!
            chatArea.Dispatcher.Invoke(() => 
            { 
                var s = new StringBuilder(chatArea.Text); 
                s.Append( $"[{e.User}] {e.Message}" ).Append(System.Environment.NewLine); 
                chatArea.Text = s.ToString(); 
            });
        }

        private void FR_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as ThePlaceToMeet.Wpf.App.App;
            app?.SetLanguage("fr-FR");
        }

        private void EN_Click(object sender, RoutedEventArgs e)
        {
            var app = Application.Current as ThePlaceToMeet.Wpf.App.App;
            app?.SetLanguage("en-US");
        }

        private void userInputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               SignalRClient.Instance.SendMessage(userName.Text, inputText.Text);
            }
        }
    }
}
