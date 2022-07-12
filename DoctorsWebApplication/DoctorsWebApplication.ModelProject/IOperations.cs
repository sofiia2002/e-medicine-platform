namespace DoctorsWebApplication.ModelProject
{
  using System.Threading.Tasks;

  public interface IOperations
  {
        //void LoadNodeList( );

        Task LoadAppointments();

        Task LoadAppointmentDetails();

        Task LoadPatients();

        Task LoadAvailability();

        //void LoadAvailability();

        Task DeleteDoctorAvailability();

        Task AddDoctorAvailability();

    }
}
