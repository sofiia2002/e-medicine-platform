namespace DoctorsClientApplication.View
{
    using Windows.UI.Xaml.Controls;
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Controller;
    using DoctorsClientApplication.Utilities;

    public sealed partial class MyPatients : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public MyPatients()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;
        }
    }
}
