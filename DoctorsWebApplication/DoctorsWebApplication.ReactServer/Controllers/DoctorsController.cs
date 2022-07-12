using DoctorsWebApplication.ModelProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsWebApplication.ReactServer.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IModel model;

        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(ILogger<DoctorsController> logger, IModel model)
        {
            this.model = model;
            _logger = logger;
        }

        [HttpGet("doctor-info")]
        public async Task<DoctorData> GetDoctorInfo()
        {
            await Task.Delay(1);
            return this.model.Doctor;
        }

        [HttpGet("my-appointments")]
        public async Task<IEnumerable<AppointmentData>> GetApointments()
        {
            await Task.Run(() => this.model.LoadAppointments());
            return this.model.Appointments;
        }

        [HttpGet("my-patients")]
        public async Task<IEnumerable<PatientData>> GetPaients()
        {
            await Task.Run(()=> this.model.LoadPatients());
            return this.model.Patients;
        }

        [HttpGet("my-availabilities")]
        public async Task<IEnumerable<AvailabilityData>> GetAvailabilities()
        {
            await Task.Run(() => this.model.LoadAvailability());
            return this.model.Availabilities;
        }

        [HttpPost("appointment-details-patient")]
        public async Task<PatientData> GetAppointmentDetailsPatient(AppointmentData appointment)
        {
            await Task.Run(() => this.model.SelectedAppointment = appointment);
            await Task.Run(() => this.model.LoadAppointmentDetails());

            return this.model.PatientDetails;
        }

        [HttpPost("appointment-details")]
        public async Task<AppointmentData> GetAppointmentDetails(AppointmentData appointment)
        {
            await Task.Run(() => this.model.SelectedAppointment = appointment);
            await Task.Run(() => this.model.LoadAppointmentDetails());

            return this.model.AppointmentDetails;
        }

        [HttpPost("add-availabiity")]
        public async Task<IEnumerable<AvailabilityData>> AddDoctorAvailability(AvailabilityData availability)
        {
            await Task.Run(() => this.model.AvailabilityDateTime = availability.Start_Date);
            await Task.Run(() => this.model.AddDoctorAvailability());
            await Task.Run(() => this.model.LoadAvailability());
            return this.model.Availabilities;
        }

        [HttpPost("delete-availability")]
        public async Task<IEnumerable<AvailabilityData>> DeleteDoctorAvailability(AvailabilityData availability)
        {
            await Task.Run(() => this.model.SelectedAvailability = availability);
            await Task.Run(() => this.model.DeleteDoctorAvailability());
            await Task.Run(() => this.model.LoadAvailability());
            return this.model.Availabilities;
        }
    }
}
