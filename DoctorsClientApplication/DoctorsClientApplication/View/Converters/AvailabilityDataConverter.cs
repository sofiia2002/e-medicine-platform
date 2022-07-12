namespace DoctorsClientApplication.View
{
    using System;
    using Windows.UI.Xaml.Data;
    using DoctorsClientApplication.Model;

    public class AvailabilityDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            AvailabilityData availabilityData = (AvailabilityData)value; 

            string startMinutes = availabilityData.Start_Date.Minute.ToString();

            string endMinutes = availabilityData.End_Date.Minute.ToString();

            if (availabilityData.Start_Date.Minute < 10)
            {
                startMinutes = "0" + startMinutes;
            }

            if (availabilityData.End_Date.Minute < 10)
            {
                endMinutes = "0" + endMinutes;
            }

            return String.Format("{0}.{1}.{2}, From {3}:{4}, To {5}:{6}", availabilityData.Start_Date.Day, availabilityData.Start_Date.Month, availabilityData.Start_Date.Year, availabilityData.Start_Date.Hour, startMinutes, availabilityData.End_Date.Hour, endMinutes);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}