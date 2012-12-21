using System.Windows;
using Microsoft.Practices.Unity;
using StructureMap;

namespace DIExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container StructureMapContainer;
        public static UnityContainer UnityContainer;

        protected override void OnStartup(StartupEventArgs e)
        {
            //createViewByHand().Show();
            //createViewByStructureMap().Show();
            createViewByUnity().Show();
        }

        private static Window createViewByHand()
        {
            return new MainWindow(new Presenter(LoggerFactory.CreateLogger(), ModelFactory.CreateModel()));
        }

        private static Window createViewByStructureMap()
        {
            StructureMapContainer = new StructureMap.Container(x =>
            {
                x.For<IPresenter>().Use<Presenter>();
                x.For<IView>().Use<MainWindow>();
                x.For<IModel>().Singleton().Use<ReverseModel>();
                x.AddType(typeof(ILogger), typeof(MessageBoxLogger), LoggerFactory.MessageboxLoggerName);
                x.AddType(typeof(ILogger), typeof(ConsoleLogger), LoggerFactory.ConsoleLoggerName);
                x.For<ILogger>().Singleton().UseSpecial(y => y.TheInstanceNamed(LoggerFactory.ConsoleLoggerName));
            });
            StructureMapContainer.AssertConfigurationIsValid();

            return StructureMapContainer.GetInstance<MainWindow>();
        }


        private Window createViewByUnity()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IPresenter, Presenter>();
            UnityContainer.RegisterType<IView, MainWindow>();
            UnityContainer.RegisterType<IModel, ReverseModel>(new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<ILogger, ConsoleLogger>(LoggerFactory.ConsoleLoggerName,
                                                                new ContainerControlledLifetimeManager());
            UnityContainer.RegisterType<ILogger, MessageBoxLogger>(LoggerFactory.MessageboxLoggerName,
                                                                   new ContainerControlledLifetimeManager());
            return UnityContainer.RegisterInstance(typeof(ILogger), UnityContainer.Resolve<ILogger>(LoggerFactory.ConsoleLoggerName)).Resolve<MainWindow>();
        }
    }
}
