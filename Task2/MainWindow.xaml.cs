using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        bool isConnected = false;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            if (isConnected)
                text.Text += "\nДані отримані";
        }
        private async void ConnectToDB(object sender, RoutedEventArgs e)
        {
            Loading("Підключення");
            await Task.Delay(new Random().Next() % 2000 + 3000);
            isConnected = true;
            text.Text = "Підключено до бази даних";
            timer.Start();
        }
        private async void DisconnectDB(object sender, RoutedEventArgs e)
        {
            Loading("Відключення");
            isConnected = false;
            await Task.Delay(new Random().Next() % 2000 + 3000);
            text.Text = "Відключено від бази дани";
            timer.Stop();
        }
        private async Task Loading(string messege)
        {
            text.Text = messege;
            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(1000);
                text.Text += " .";
            }
        }
    }
}
