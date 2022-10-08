using Adita.Wpf.Hosting.Sample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Adita.Wpf.Hosting.Sample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.Current.ServiceProvider.GetRequiredService<MainViewModel>();

            var color = App.Current.Resources["testColor"];
        }
    }
}
