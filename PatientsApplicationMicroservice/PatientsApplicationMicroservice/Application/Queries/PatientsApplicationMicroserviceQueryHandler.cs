namespace PatientsApplicationMicroservice.Web.Application.Queries
{
    using System;
    using PatientsApplicationMicroservice.Web.Application.DataServiceClients;
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientsApplicationMicroserviceQueryHandler : IPatientsApplicationMicroserviceQueryHandler
    {
        private readonly IPatientsDatabaseClient patientsDatabaseClient;
        private readonly IAvailabilityDatabaseClient availabilityDatabaseClient;

        public PatientsApplicationMicroserviceQueryHandler(IPatientsDatabaseClient patientsDatabaseClient, IAvailabilityDatabaseClient availabilityDatabaseClient)
        {
            this.patientsDatabaseClient = patientsDatabaseClient;
            this.availabilityDatabaseClient = availabilityDatabaseClient;
        }

        public PatientsApplicationMicroserviceQueryHandler()
        {

        }


        public async Task<List<AppointmentDto>> GetPatientsAppointmentsAsync(string pesel)
        {
            var appointments = await patientsDatabaseClient.GetPatientsAppointments(pesel);
            return appointments.OrderByDescending(appointment => appointment.StartDate).ToList();
        }

        public async Task<List<AvailabilityDto>> GetDoctorScheduleAsync(string pwz)
        {
            return (await availabilityDatabaseClient.GetDoctorScheduleAsync(pwz)).ToList();
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
            return (await availabilityDatabaseClient.GetAllDoctorsAsync()).ToList();
        }

        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {
            return await availabilityDatabaseClient.GetDoctorByPwzAsync(pwz);
        }

        public async Task<List<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            return (await availabilityDatabaseClient.GetAllAvailabilitiesAsync()).ToList();
        }

        public async Task<List<DoctorDto>> GetDoctorsBySpecializationAsync(string id)
        {
            return (await availabilityDatabaseClient.GetDoctorsBySpecializationAsync(id)).ToList();
        }

        public async Task AddAppointmentAsync(RawAppointmentDto rawAppointment, string pwzRaw, DateTime startDateRaw)
        {
            await patientsDatabaseClient.AddAppointment(rawAppointment);
            await availabilityDatabaseClient.DeleteAvailability(pwzRaw, startDateRaw);
        }

        public async Task DeleteAppointmentAsync(int id, string pwz, DateTime startDate)
        {
            await patientsDatabaseClient.DeleteAppointment(id);
            await availabilityDatabaseClient.CancelAvailability(pwz, startDate);
        }

        public async Task<List<DoctorDto>> GetMyDoctorsAsync(string pesel)
        {
            List<DoctorDto> allDoctors = new List<DoctorDto>();
            var appointments = await patientsDatabaseClient.GetPatientsAppointments(pesel);
            appointments.OrderByDescending(appointment => appointment.StartDate).ToList();
            List<string> pwzList = new List<string>();

            foreach(AppointmentDto appointment in appointments)
            {
                if (!pwzList.Contains(appointment.PWZ))
                    pwzList.Add(appointment.PWZ);
            }

            foreach (string pwz in pwzList)
            {
                var doctor = await availabilityDatabaseClient.GetDoctorByPwzAsync(pwz);
                allDoctors.Add(doctor);
            }

            return allDoctors;
        }

    }
}
