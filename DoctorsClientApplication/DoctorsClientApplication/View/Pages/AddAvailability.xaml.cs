namespace DoctorsClientApplication.View
{
    using System;
    using Windows.UI.Xaml.Controls;
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Controller;
    using DoctorsClientApplication.Utilities;

    public sealed partial class AddAvailability : Page
    {

        public IData Model { get; private set; }

        public IController Controller { get; private set; }

        public AddAvailability()
        {
            this.InitializeComponent();

            IEventDispatcher dispatcher = new EventDispatcher() as IEventDispatcher;

            this.Controller = ControllerFactory.GetController(dispatcher);

            this.Model = this.Controller.Model as IData;

            this.DataContext = this.Controller;

            this.Model.AvailabilityDateTime = DateTime.Now;
            MyDatePicker.MinYear = DateTime.Now;
            MyDatePicker.SelectedDate = DateTime.Now;
            MyTimePicker.SelectedTime = new TimeSpan((DateTime.Now.Hour + 1), 0, 0);
        }

        private void AvailabilityDateTime_SelectedTimeChanged(TimePicker sender, TimePickerSelectedValueChangedEventArgs args)
        {
            if (MyTimePicker.SelectedTime != null)
            {
                if (MyTimePicker.Time.Hours < 8)
                {
                    MyTimePicker.SelectedTime = new TimeSpan(8, 0, 0);
                }
                else if(MyTimePicker.Time.Hours > 20)
                {
                    MyTimePicker.SelectedTime = new TimeSpan(19, 0, 0);
                }

                this.Model.AvailabilityDateTime = new DateTime(MyDatePicker.Date.Year, MyDatePicker.Date.Month, MyDatePicker.Date.Day,
                                           MyTimePicker.Time.Hours, MyTimePicker.Time.Minutes, MyTimePicker.Time.Seconds);
            }
        }

        private void AvailabilityDateTime_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (MyDatePicker.SelectedDate != null)
            {
                this.Model.AvailabilityDateTime = new DateTime(MyDatePicker.Date.Year, MyDatePicker.Date.Month, MyDatePicker.Date.Day,
                                           MyTimePicker.Time.Hours, MyTimePicker.Time.Minutes, MyTimePicker.Time.Seconds);
            }
        }
    }
}
