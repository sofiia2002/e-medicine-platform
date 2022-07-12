namespace DoctorsClientApplication.View
{
    using Windows.Foundation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.ViewManagement;
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Controller;
    using DoctorsClientApplication.Utilities;

    public sealed partial class MainPage : Page
    {
        public IData Model { get; private set; }

        public IOperations ModelOperations { get; private set; }

        public IController Controller { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();
            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;
            if (ContentFrame.Content == null)
            {
                ContentFrame.Navigate(typeof(HomePage));
            }
        }

        private void FormName_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(1500, 1000));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;

                switch(item.Tag.ToString())
                {
                    case "home":
                        ContentFrame.Navigate(typeof(HomePage));
                        NavView.Header = "Home";
                        break;
                    case "schedule":
                        ContentFrame.Navigate(typeof(SchedulePage));
                        NavView.Header = "Your Appointments";
                        break;
                    case "availability":
                        ContentFrame.Navigate(typeof(AvailabilityPage));
                        NavView.Header = "Your Availabilities";
                        break;
                    case "add-availability":
                        ContentFrame.Navigate(typeof(AddAvailability));
                        NavView.Header = "Add Availability";
                        break;
                    case "patients":
                        ContentFrame.Navigate(typeof(MyPatients));
                        NavView.Header = "My Patients";
                        break;
                }
            }
        }
    }
}
