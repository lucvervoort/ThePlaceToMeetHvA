using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using ThePlaceToMeet.ConfigCrypter.Extensions;

/*
// IdentityServer
using IdentityModel.OidcClient;
using IdentityModel;
using System.Net.Sockets;
*/

namespace ThePlaceToMeet.Wpf.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ILogger<App> _logger;

        public IHost Host { get; }

        public App()
        {
            Host = new HostBuilder()
                 .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
                 {
                     configurationBuilder.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
                     configurationBuilder.AddJsonFile("appsettings.json", optional: false);
                     configurationBuilder.AddEncryptedAppSettings(hostingContext.HostingEnvironment, crypter =>
                          {
                              crypter.CertificatePath = "cert.pfx";
                              crypter.KeysToDecrypt = new List<string> { "Nested:KeyToEncrypt" };
                          });                      
                 })
                .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();

                /*
                // IdentityServer: setup OidcClient
                services.AddSingleton(new OidcClient(new()
                {
                    Authority = "https://localhost:5005", //  "https://demo.duendesoftware.com",

                    ClientId = "interactive.public",
                    ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0",
                    Scope = "openid profile test.api",
                    RedirectUri = "https://localhost:5005/Account/Login",
                    Browser = new WpfAuthenticationBrowser()
                }));
                */
            })
            .UseSerilog((ctx, lc) => lc.WriteTo.Debug()
                .Enrich.WithThreadId()
                .Enrich.WithCorrelationId()
                .Enrich.WithThreadName()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Version", "1.0.0")
                .ReadFrom.Configuration(ctx.Configuration))
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddSerilog();
            })
            .Build();

            _logger = Host.Services.GetRequiredService<ILogger<App>>();
            _logger.LogInformation("Host created and WPF application started.");

            // TODO: startup using language of OS
            SetLanguage("en-US");
        }

        public void SetLanguage(string culture = "")
        {
            _logger?.LogInformation($"Setting language to {culture}");
            string c = culture;
            if (string.IsNullOrEmpty(c))
            {
                c = Thread.CurrentThread.CurrentCulture.ToString();
            }
            var f = ".\\Resources\\Translations.xaml";
            var potentialTranslationFile = ".\\Resources\\Translations." + c + ".xaml";
            if (Path.Exists(potentialTranslationFile))
            {
                f = potentialTranslationFile;
            }
            this.Resources.MergedDictionaries.Clear();
            ResourceDictionary dict = new()
            {
                Source = new Uri(f, UriKind.Relative)
            };
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _logger?.LogError($"Caught top level exception {e.Exception.Message}");
            MessageBox.Show(e.Exception.Message);
            e.Handled = true; // required: otherwise exception is still thrown
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            _logger?.LogDebug($"Starting application host and launching main window");

            await Host.StartAsync();

            var mainWindow = Host.Services.GetService<MainWindow>();

            SignalRClient.Instance.Initialize();

            mainWindow?.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            _logger?.LogDebug($"Starting application host");

            using (Host)
            {
                await Host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
