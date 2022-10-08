using Adita.Wpf.Hosting.Sample.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.Wpf.Hosting.Sample
{
    public class Startup
    {
        [STAThread]
        public static void Main()
        {
            IApplicationBuilder<App> builder = new ApplicationBuilder<App>();

            builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
            });

            App application = builder.Build();
            //if app has startup uri, in here need to call InitializeComponent()
            application.Run();
        }
    }
}
