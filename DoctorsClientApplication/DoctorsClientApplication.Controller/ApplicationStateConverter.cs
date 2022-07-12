namespace DoctorsClientApplication.Controller
{
  using System;
  using Windows.UI.Xaml.Data;

  public class ApplicationStateConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      ApplicationState applicationState = (ApplicationState)value;

      string applicationStateName = applicationState.ToString( );

      return applicationStateName;
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      string applicationStateName = (string)value;

      ApplicationState applicationState = (ApplicationState)Enum.Parse( typeof( ApplicationState ), applicationStateName );

      return applicationState;
    }
  }
}