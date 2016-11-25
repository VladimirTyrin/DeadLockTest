using System.Threading.Tasks;
using System.Windows;

namespace DeadLockTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static async Task<string> DoWorkAsync()
        {
            await Task.Delay(2000);
            return "Done";
        }

        private void WaitButton_OnClick(object sender, RoutedEventArgs e)
        {
            StateLabel.Content = "Started wait";
            var result = DoWorkAsync().Result;
            StateLabel.Content = result;
        }

        private async void AwaitButton_OnClick(object sender, RoutedEventArgs e)
        {
            StateLabel.Content = "Started await";
            var result = await DoWorkAsync();
            StateLabel.Content = result;
        }
    }
}
