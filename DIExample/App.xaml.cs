using System.Windows;

namespace DIExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            createViewByHand().Show();
        }

        private static Window createViewByHand()
        {
            return new MainWindow(new Presenter(LoggerFactory.CreateLogger(), ModelFactory.CreateModel()));
        }
    }
}
