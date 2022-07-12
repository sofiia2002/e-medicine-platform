namespace PatientsDatabase.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using PatientsDatabase.Web.Application.Dtos;
    using PatientsDatabase.Web.Application.Queries;

    [ApiController]
    public class PatientsDatabaseController : ControllerBase
    {
        private readonly ILogger<PatientsDatabaseController> logger;

        private readonly IPatientsDatabaseQueriesHandler patientsDatabaseQueriesHandler;

        public PatientsDatabaseController(IPatientsDatabaseQueriesHandler patientsDatabaseQueriesHandler, ILogger<PatientsDatabaseController> logger)
        {
            this.logger = logger;
            this.patientsDatabaseQueriesHandler = patientsDatabaseQueriesHandler;
        }

        [HttpGet]
        [Route("get-appointments")]
        public IEnumerable<AppointmentDto> GetAppointments()
        {
            return this.patientsDatabaseQueriesHandler.GetAppointments();
        }

        [HttpGet]
        [Route("get-appointments-by-pwz")]
        public IEnumerable<AppointmentDto> GetAppointmentsByPwz(string pwz)
        {
            return this.patientsDatabaseQueriesHandler.GetAppointmentsByPwz(pwz);
        }

        [HttpGet]
        [Route("get-appointments-by-pesel")]
        public IEnumerable<AppointmentDto> GetAppointmentsByPesel(string pesel)
        {
            return this.patientsDatabaseQueriesHandler.GetAppointmentsByPesel(pesel);
        }

        [HttpGet]
        [Route("get-patients")]
        public IEnumerable<PatientDto> GetPatients()
        {
            return this.patientsDatabaseQueriesHandler.GetPatients().ToArray();
        }

        [HttpPost]
        [Route("post-appointment")]
        public void AddAppointment(RawAppointmentDto rawAppointmentDto)
        {
            this.patientsDatabaseQueriesHandler.AddAppointment(rawAppointmentDto);
        }


        [HttpDelete]
        [Route("delete-appointment")]
        public void DeleteAppointment(int id)
        {
            this.patientsDatabaseQueriesHandler.DeleteAppointment(id);
        }

    }
}
