using Adita.Wpf.Hosting.Sample.Models.Options;
using Adita.Wpf.Hosting.Sample.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.IO;

namespace Adita.Wpf.Hosting.Sample
{
    public class Startup
    {
        [STAThread]
        public static void Main()
        {
            IApplicationBuilder<App> builder = new ApplicationBuilder<App>();

            //setup configuration
            string appSettingsPath = Path.Combine(Environment.CurrentDirectory, "AppSettings.json");

            builder.ConfigureAppConfiguration(configBuilder =>
            {
                configBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true);
            });

            //add services
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.Configure<TestOptions>(builder.Configuration.GetSection(nameof(TestOptions)));
            });

            App application = builder.Build();

            //if App has components such as StartupUri, subscribes event handler to event(s) or others in here need to call InitializeComponent()
            //InitializeComponent method of App class only will generated after build if any component exist.
            //Note: if you delete the StartupUri on App.xaml you need to handle Startup event, otherwise InitializeComponent will never be generated
            //and your app resource will not be initialized too, this is such as bugs of wpf!!!.

            application.InitializeComponent();

            application.Run();
        }
    }
}
