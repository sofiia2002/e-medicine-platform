namespace DoctorsClientApplication.View
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using DoctorsClientApplication.View;
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Controller;
    using DoctorsClientApplication.Utilities;

    public sealed partial class SchedulePage : Page
    {
        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public SchedulePage()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

        }

        void DetailEventHandler(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedAppointment == null)
            {
                AppointmentDataTextBlock.Opacity = 0;
                AppointmentNotSelectedInfo.Opacity = 1;
            } else
            {
                AppointmentDataTextBlock.Opacity = 1;
                AppointmentNotSelectedInfo.Opacity = 0;  
            }
        }
    }
}
