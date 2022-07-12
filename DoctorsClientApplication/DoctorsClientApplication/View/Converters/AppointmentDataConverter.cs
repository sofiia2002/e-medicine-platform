namespace DoctorsClientApplication.View
{
    using System;
    using Windows.UI.Xaml.Data;
    using DoctorsClientApplication.Model;

    public class AppointmentDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            AppointmentData appointmentData = (AppointmentData)value;

            string startMinutes = appointmentData.StartDate.Minute.ToString();

            if (appointmentData.StartDate.Minute < 10)
            {
                startMinutes = "0" + startMinutes;
            }

            return String.Format("{0}.{1}.{2}, From {3}:{4}, To {5}:{6}", appointmentData.StartDate.Day, appointmentData.StartDate.Month, appointmentData.StartDate.Year, appointmentData.StartDate.Hour, startMinutes, (appointmentData.StartDate.Hour + 1), startMinutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}