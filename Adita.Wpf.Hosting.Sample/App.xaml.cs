using Adita.Wpf.Hosting.Sample.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;

namespace Adita.Wpf.Hosting.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IApplication
    {
        #region Public properties
        new public static App Current => (App)Application.Current;
        public IServiceProvider ServiceProvider { get; private set; } = default!;
        public IConfiguration Configuration { get; private set; } = default!;
        #endregion Public properties

        #region IApplication methods implementations
        public void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }
        #endregion IApplication methods implementations

        #region Event handlers
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow();
            MainWindow.Show();
        }
        #endregion Event handlers
    }
}
