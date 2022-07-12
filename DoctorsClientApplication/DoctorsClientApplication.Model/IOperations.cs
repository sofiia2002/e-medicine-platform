namespace DoctorsClientApplication.Model
{
    using System.Threading.Tasks;

    public interface IOperations
    {
        Task LoadAppointments();

        Task LoadAppointmentDetails();

        Task LoadPatients();

        Task LoadAvailability();

        Task DeleteDoctorAvailability();

        Task AddDoctorAvailability();
    }
}
