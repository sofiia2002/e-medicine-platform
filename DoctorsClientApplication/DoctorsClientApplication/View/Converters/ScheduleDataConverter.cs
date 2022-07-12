namespace DoctorsClientApplication.View
{
    using System;
    using Windows.UI.Xaml.Data;
    using DoctorsClientApplication.Model;

    public class ScheduleDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ScheduleData appointmentData = (ScheduleData)value;

            string startMinutes = appointmentData.Start_Date.Minute.ToString();

            string endMinutes = appointmentData.End_Date.Minute.ToString();

            if (appointmentData.Start_Date.Minute<10)
            {
                startMinutes = "0"  + startMinutes;
            }

            if (appointmentData.End_Date.Minute < 10)
            {
                endMinutes = "0" + endMinutes;
            }

            return String.Format("{0}.{1}.{2}, From {3}:{4}, To {5}:{6}", appointmentData.Start_Date.Day, appointmentData.Start_Date.Month, appointmentData.Start_Date.Year, appointmentData.Start_Date.Hour, startMinutes, appointmentData.End_Date.Hour, endMinutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}