using System;
namespace PatientsDatabase.Domain.Services
{
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public interface IDatabase
    {
        Patient[] GetPatients();

        Appointment[] GetAppointments();

        Appointment[] GetAppointmentsByPwz(string pwz);

        Appointment[] GetAppointmentsByPesel(string pesel);

        void AddAppointment(Appointment appointment);

        void DeleteAppointment(int id);
    }
}