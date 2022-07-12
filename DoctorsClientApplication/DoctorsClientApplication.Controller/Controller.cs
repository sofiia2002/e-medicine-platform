namespace DoctorsClientApplication.Controller
{
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Utilities;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.SearchAppointmentsCommand = new ControllerCommand(this.SearchAppointments);

            this.ShowPatientsCommand = new ControllerCommand(this.ShowPatients);

            this.SearchAppointmentDetailsCommand = new ControllerCommand(this.SearchAppointmentDetails);

            this.ShowDoctorScheduleCommand = new ControllerCommand(this.ShowDoctorSchedule);

            this.ShowAppointmentPageCommand = new ControllerCommand(this.ShowAppointmentPage);

            this.SetDefaultStateCommand = new ControllerCommand(this.SetDefaultState);

            this.AddDoctorAvailabilityCommand = new ControllerCommand(this.AddDoctorAvailability);

            this.DeleteDoctorAvailabilityCommand = new ControllerCommand(this.DeleteDoctorAvailability);

            this.SearchAvailabilitiesCommand = new ControllerCommand(this.SearchAvailabilities);

        }
    }
}
