namespace PatientsDatabase.Web.Application.Queries
{
    using PatientsDatabase.Web.Application.Dtos;
    using PatientsDatabase.Web.Application.Mapper;
    using PatientsDatabase.Domain.Services;
    using System.Collections.Generic;
    using System.Linq;


    public class PatientsDatabaseQueriesHandler : IPatientsDatabaseQueriesHandler
    {
        private readonly IDatabase database;

        public PatientsDatabaseQueriesHandler(IDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<PatientDto> GetPatients()
        {
            return database.GetPatients().Select(el=>el.MapToDto());
        }

        public IEnumerable<AppointmentDto> GetAppointments()
        {
            return database.GetAppointments().Select(el=>el.MapToDto());
        }

        public IEnumerable<AppointmentDto> GetAppointmentsByPwz(string pwz)
        {
            return database.GetAppointmentsByPwz(pwz)?.Select(el=>el.MapToDto());
        }

        public IEnumerable<AppointmentDto> GetAppointmentsByPesel(string pesel)
        {
            return database.GetAppointmentsByPesel(pesel)?.Select(el=>el.MapToDto());
        }

        public void AddAppointment(RawAppointmentDto rawAppointment)
        {
            var lastAppointment = this.database.GetAppointments()[this.database.GetAppointments().Count() - 1];
            var appointment = new AppointmentDto
            {
                AppointmentId = lastAppointment.Id + 1,
                PESEL = rawAppointment.PESEL,
                PWZ = rawAppointment.PWZ,
                StartDate = rawAppointment.StartDate
            };
            database.AddAppointment(appointment.MapFromDto());
        }

        public void DeleteAppointment(int id)
        {
            database.DeleteAppointment(id);
        }
    }
}
