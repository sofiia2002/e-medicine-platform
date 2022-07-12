namespace DoctorsClientApplication.Controller
{
    using System.ComponentModel;
    using System.Windows.Input;
    using DoctorsClientApplication.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand ShowPatientsCommand { get; }
        ICommand SearchAppointmentsCommand { get; }

        ICommand SearchAppointmentDetailsCommand { get; }

        ICommand ShowDoctorScheduleCommand { get; }

        ICommand ShowAppointmentPageCommand { get; }

        ICommand SetDefaultStateCommand { get; }

        ICommand DeleteDoctorAvailabilityCommand { get; }

        ICommand AddDoctorAvailabilityCommand { get; }

        ICommand SearchAvailabilitiesCommand { get; }
    }
}
