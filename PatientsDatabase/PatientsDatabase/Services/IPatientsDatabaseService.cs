namespace PatientsDatabase.Domain.Services
{
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public interface IPatientsDatabaseService
    {
        Appointment[] GetAppointments();
        Patient[] GetPatients();
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}
