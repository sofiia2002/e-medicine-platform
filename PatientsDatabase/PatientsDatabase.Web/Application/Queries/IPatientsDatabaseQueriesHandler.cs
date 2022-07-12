namespace PatientsDatabase.Web.Application.Queries
{
    using System.Collections.Generic;
    using PatientsDatabase.Web.Application.Dtos;

    public interface IPatientsDatabaseQueriesHandler
    {
        IEnumerable<PatientDto> GetPatients();
        IEnumerable<AppointmentDto> GetAppointments();
        IEnumerable<AppointmentDto> GetAppointmentsByPwz(string pwz);
        IEnumerable<AppointmentDto> GetAppointmentsByPesel(string pesel);
        void AddAppointment(RawAppointmentDto rawAppointmentDto);
        void DeleteAppointment(int id);
    }
}
