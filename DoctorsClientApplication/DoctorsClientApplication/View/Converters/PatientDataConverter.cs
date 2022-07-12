namespace DoctorsClientApplication.View
{
    using System;
    using Windows.UI.Xaml.Data;
    using DoctorsClientApplication.Model;

    public class PatientDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            PatientData patientData = (PatientData)value;

            return String.Format("Name: {0} {3}Surname: {1} {3}PESEL: {2}", patientData.FirstName, patientData.LastName, patientData.PESEL, System.Environment.NewLine);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}