namespace DoctorsClientApplication.Controller
{
    using System.Windows.Input;

    public partial class Controller : IController
    {
        public ApplicationState CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                this.RaisePropertyChanged("CurrentState");
            }
        }
        private ApplicationState currentState = ApplicationState.Default;

        public ICommand ShowPatientsCommand { get; private set; }
        public ICommand SearchAppointmentsCommand { get; private set; }

        public ICommand SearchAppointmentDetailsCommand { get; private set; }

        public ICommand ShowDoctorScheduleCommand { get; private set; }

        public ICommand ShowAppointmentPageCommand { get; private set; }

        public ICommand SetDefaultStateCommand { get; private set; }

        public ICommand SearchAvailabilitiesCommand { get; private set; }

        public ICommand DeleteDoctorAvailabilityCommand { get; private set; }

        public ICommand AddDoctorAvailabilityCommand { get; private set; }

        private void SearchAvailabilities()
        {
            this.Model.LoadAvailability();
        }

        private void SearchAppointmentDetails()
        {
            this.Model.LoadAppointmentDetails();
            this.ShowAppointmentPage();
        }

        private void AddDoctorAvailability()
        {
            this.Model.AddDoctorAvailability();
        }

        private void DeleteDoctorAvailability()
        {
            this.Model.DeleteDoctorAvailability();
        }

        private void SetDefaultState()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.Default:
                    break;

                default:
                    this.CurrentState = ApplicationState.Default;
                    break;
            }
        }

        private void ShowDoctorSchedule()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.DoctorSchedule:
                    break;

                default:
                    this.CurrentState = ApplicationState.DoctorSchedule;
                    break;
            }
        }

        private void ShowAppointmentPage()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.AppointmentPage:
                    break;

                default:
                    this.CurrentState = ApplicationState.AppointmentPage;
                    break;
            }
        }

        private void ShowPatients()
        {
            Model.LoadPatients();
        }
        private void SearchAppointments()
        {
            this.Model.LoadAppointments();
            this.ShowDoctorSchedule();
        }

    }
}
