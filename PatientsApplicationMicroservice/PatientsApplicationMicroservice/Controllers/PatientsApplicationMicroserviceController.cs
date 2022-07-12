namespace PatientsApplicationMicroservice.Web.Application
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using PatientsApplicationMicroservice.Web.Application.Queries;
    using PatientsApplicationMicroservice.Web.Application.Dtos;

    [ApiController]
    public class PatientsApplicationMicroserviceController : ControllerBase
    {
        private readonly ILogger<PatientsApplicationMicroserviceController> logger;
        private readonly IPatientsApplicationMicroserviceQueryHandler patientsApplicationMicroserviceHandler;

        public PatientsApplicationMicroserviceController(ILogger<PatientsApplicationMicroserviceController> logger, IPatientsApplicationMicroserviceQueryHandler patientsApplicationMicroserviceHandler)
        {
            this.logger = logger;
            this.patientsApplicationMicroserviceHandler = patientsApplicationMicroserviceHandler;
        }

        [HttpGet("appointments")]
        public async Task<List<AppointmentDto>> GetPatientsAppointmentsAsync(string pesel)
        {
            return await patientsApplicationMicroserviceHandler.GetPatientsAppointmentsAsync(pesel);
        }

        [HttpGet("availabilities")]
        public async Task<List<AvailabilityDto>> GetPatientsAppointmentsAsync()
        {
            return await patientsApplicationMicroserviceHandler.GetAllAvailabilitiesAsync();
        }

        [HttpGet("doctors")]
        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
           return await patientsApplicationMicroserviceHandler.GetAllDoctorsAsync();
        }
   
        [HttpGet("doctors-by-specialization")]
        public async Task<List<DoctorDto>> GetDoctorsBySpecializationAsync(string id)
        {
           return await patientsApplicationMicroserviceHandler.GetDoctorsBySpecializationAsync(id);
        }

        [HttpGet("doctor-schedule")]
        public async Task<List<AvailabilityDto>> GetDoctorScheduleAsync(string pwz)
        {
           return await patientsApplicationMicroserviceHandler.GetDoctorScheduleAsync(pwz);
        }

        [HttpGet("doctor-by-pwz")]
        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {
           return await patientsApplicationMicroserviceHandler.GetDoctorByPwzAsync(pwz);
        }

        [HttpGet("my-doctors")]
        public async Task<List<DoctorDto>> MyDoctorsAsync(string pesel)
        {
            return await patientsApplicationMicroserviceHandler.GetMyDoctorsAsync(pesel);
        }

        [HttpPost("appointment")]
        public async Task PostPatientsAppointmentsAsync(RawAppointmentDto rawAppointmentDto)
        {
            await patientsApplicationMicroserviceHandler.AddAppointmentAsync(rawAppointmentDto, rawAppointmentDto.PWZ, rawAppointmentDto.StartDate);
        }

        [HttpDelete("appointment")]
        public async Task DeletePatientsAppointmentsAsync(int id, string pwz, DateTime startDate)
        {
            await patientsApplicationMicroserviceHandler.DeleteAppointmentAsync(id, pwz, startDate);
        }
    }
}
