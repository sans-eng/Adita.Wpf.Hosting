using Adita.Wpf.Hosting.Sample.Models.Options;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Options;

namespace Adita.Wpf.Hosting.Sample.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel
    {
        [ObservableProperty]
        private string _content = $"This is {nameof(MainViewModel)}";
        private TestOptions _testOptions;

        public MainViewModel(IOptions<TestOptions> options)
        {
            _testOptions = options.Value;

            _content += $" with option value 1 is: {_testOptions.OptionValue1}";
        }
    }
}
