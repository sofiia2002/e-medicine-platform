namespace DoctorMicroservice.Web.Controllers
{
    using DoctorMicroservice.Web.Application.Dtos;
    using DoctorMicroservice.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class DoctorMicroserviceController
    {
        private readonly ILogger<DoctorMicroserviceController> logger;
        private readonly IDoctorMicroserviceHandler doctorMicroserviceHandler;

        public DoctorMicroserviceController(ILogger<DoctorMicroserviceController> logger, IDoctorMicroserviceHandler doctorMicroserviceHandler)
        {
            this.logger = logger;
            this.doctorMicroserviceHandler = doctorMicroserviceHandler;
        }

        [HttpGet("doctor")]
        public async Task<DoctorDto> GetDoctorAsync([FromQuery] string pwz)
        {
            return await doctorMicroserviceHandler.GetDoctorInfoAsync(pwz);
        }

        [HttpGet("doctor-schedule")]
        public async Task<IEnumerable<ScheduleDto>> GetDoctorAvailabilityAsync([FromQuery] string pwz)
        {
            return await doctorMicroserviceHandler.GetDoctorScheduleAsync(pwz);
        }

        [HttpGet("my-patients")]
        public async Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync([FromQuery] string pwz)
        {
            return await doctorMicroserviceHandler.GetDoctorPatientsAsync(pwz);
        }

        [HttpGet("patient")]
        public async Task<PatientDto> GetDoctorPatientByPeselAsync([FromQuery] string pesel, [FromQuery] string pwz)
        {
            return await doctorMicroserviceHandler.GetDoctorPatientByPeselAsync(pesel,pwz);
        }

        [HttpGet("appointments")]
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync([FromQuery] string pwz)
        {
            return await doctorMicroserviceHandler.GetAppointmentsAsync(pwz);
        }

        [HttpGet("appointment-details")]
        public async Task<AppointmentDto> GetAppointmentDetailsAsync([FromQuery] string pwz,[FromQuery] int id)
        {
            return await doctorMicroserviceHandler.GetAppointmentDetailsAsync(id, pwz);
        }

        [HttpPost("add-availability")]
        public async Task AddAvailabilityAsync([FromBody] AvailabilityDto availability)
        {
            await doctorMicroserviceHandler.AddAvailabilityAsync(availability);
        }

        [HttpDelete("remove-availability-by-id")]
        public async Task<string> RemoveAvailabilityByIdAsync([FromBody] RemoveAvailability removeAvailability)
        {
            return await doctorMicroserviceHandler.RemoveAvailabilityByIdAsync(removeAvailability);
        }

        [HttpDelete("remove-availability-by-span")]
        public async Task<string> RemoveAvailabilityBySpanAsync([FromBody] AvailabilityDto removeAvailability)
        {
            return await doctorMicroserviceHandler.RemoveAvailabilityBySpanAsync(removeAvailability);
        }

    }
}
