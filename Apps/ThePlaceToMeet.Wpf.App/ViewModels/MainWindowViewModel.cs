//using IdentityModel.Client;
using MeetingRoomService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

/*
// IdentityServer
//using IdentityModel.Client;
using IdentityModel.OidcClient;
using System.Text;
*/

namespace ThePlaceToMeet.Wpf.App.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Private properties
        /*
        // IdentityServer
        private OidcClient _client;
        private string _currentAccessToken;
        */

        private ObservableCollection<MeetingRoomViewModel>? _meetingsRooms = new();
        #endregion

        #region Public properties
        public ObservableCollection<MeetingRoomViewModel>? MeetingRooms
        {
            get
            {
                return _meetingsRooms;
            }

            set
            {
                // preconditie
                if (_meetingsRooms == value) return;

                _meetingsRooms = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _fetchCommand;
        public ICommand FetchCommand
        {
            get
            {
                _fetchCommand ??= new RelayCommand(Fetch, param => CanFetch);
                return _fetchCommand;
            }
        }

        private RelayCommand _nlCommand;
        public ICommand NlCommand
        {
            get
            {
                _nlCommand ??= new RelayCommand(ToNl, param => CanNl);
                return _nlCommand;
            }
        }

        private readonly ILogger<App> _logger;
        private readonly IConfiguration _configuration;

        // IdentityServer en DI:
        public MainWindowViewModel(ILogger<App> logger, IConfiguration configuration/*, OidcClient client*/)
        {
            _logger = logger;
            _configuration = configuration;
            //_client = client;

            var test = _configuration["Nested:KeyToEncrypt"];

            _meetingsRooms = new();
        }

        private bool _canFetch = true;

        public bool CanFetch
        {
            get => _canFetch;

            set
            {
                if (_canFetch == value) return;
                _canFetch = value;

                RaisePropertyChanged();
            }
        }

        private bool _canNl = true;

        public bool CanNl
        {
            get => _canNl;

            set
            {
                if (_canNl == value) return;
                _canNl = value;

                RaisePropertyChanged();
            }
        }

        private string _myText = "";

        [MethodValidator(nameof(MyTextValidator))]
        public string MyText
        {
            get
            {
                return _myText;
            }
            set
            {
                if (_myText != value)
                {
                    _logger?.LogDebug($"{value}");
                    // bij elke keystroke door UpdateSourceTrigger=PropertyChanged
                    _myText = value;
                    RaisePropertyChanged();
                }
            }
        }

        private bool _doMyTextCheck = false;
        public string MyTextValidator()
        {
            if (!string.IsNullOrEmpty(MyText)) _doMyTextCheck = true;
            if (!_doMyTextCheck) return null; // OK
            if (_doMyTextCheck)
            {
                if (MyText.Equals("Luc")) { return null; } // OK
            }
            return "Please specify Luc"; // ERROR
        }
       
        private void ToNl(object o)
        {
            var app = Application.Current as ThePlaceToMeet.Wpf.App.App;
            app?.SetLanguage("nl-BE");
            //CanFetch = true;
        }

        private async Task<ICollection<MeetingRoom>> FetchMeetingRooms(/*string currentAccessToken*/)
        {
            var configuredBaseURL = _configuration.GetValue<string>("AppSettings:baseURL");
            using var httpClient = new HttpClient();

            // IdentityServer
            //httpClient.SetBearerToken(currentAccessToken);

            var apiClient = new MeetingRoomClient(_configuration == null ? "https://localhost:7045" : configuredBaseURL, httpClient);
            var task = apiClient.MeetingRoomMeetingRoomsAsync();
            task.Wait(); // await would return immediately ...
            var rooms = task.Result;

            // response.ReasonPhrase?
            _logger?.LogInformation($"Got {rooms.Count} rooms");
            return rooms;
        }

        private async void Fetch(object o)
        {
            /*
            if (_currentAccessToken == null)
            {
                var txt = "?";
                var result = await _client.LoginAsync();

                if (result.IsError)
                {
                    txt = result.Error;
                    return;
                }

                _currentAccessToken = result.AccessToken;

                var sb = new StringBuilder(128);

                sb.AppendLine("claims:");
                foreach (var claim in result.User.Claims)
                {
                    sb.AppendLine($"{claim.Type}: {claim.Value}");
                }

                sb.AppendLine();
                sb.AppendLine("access token:");
                sb.AppendLine(result.AccessToken);

                if (!string.IsNullOrWhiteSpace(result.RefreshToken))
                {
                    sb.AppendLine();
                    sb.AppendLine("access token:");
                    sb.AppendLine(result.AccessToken);
                }

                txt = sb.ToString();
            }
            */
            try
            {
                foreach (var room in FetchMeetingRooms().Result)
                {
                    var meetingRoomViewModel = new MeetingRoomViewModel()
                    {
                        Id = room.Id,
                        Naam = room.Naam,
                        PrijsPerPersoonStandaardCatering = (decimal)room.PrijsPerPersoonStandaardCatering,
                        PrijsPerUur = (decimal)room.PrijsPerUur,
                        MaximumAantalPersonen = room.MaximumAantalPersonen,
                        VergaderruimteType = room.VergaderruimteType
                    };
                    MeetingRooms?.Add(meetingRoomViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
            }
        }
        #endregion
    }
}