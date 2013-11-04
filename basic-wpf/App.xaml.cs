namespace basic.wpf
{
    using System.Threading;
    using System.Windows;

    using StructureMap;

    using basic.wpf.Statistics;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IOperationResult applicationTimer;

        static App()
        {
            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                s.TheCallingAssembly();
                s.RegisterConcreteTypesAgainstTheFirstInterface();
            }));

        }

        public App() : this(ObjectFactory.GetInstance<IOperationTimer>())
        {            
        }

        public App(IOperationTimer operationTimer)
        {
            applicationTimer = operationTimer.Begin("Application");
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            applicationTimer.Dispose();
            
        }
    }
}
