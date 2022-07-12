namespace DoctorMicroservice.Web.Application.Queries
{
    using DoctorMicroservice.Web.Application.DataServiceClients;
    using DoctorMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class DoctorMicroServiceQueryHandler : IDoctorMicroserviceHandler
    {
        private readonly IPatientsDatabaseClient patientsServiceClient;
        private readonly IDoctorsDatabaseServiceClient doctorsServiceClient;

        public DoctorMicroServiceQueryHandler(IDoctorsDatabaseServiceClient doctorsServiceClient, IPatientsDatabaseClient patientsServiceClient)
        {
            this.patientsServiceClient = patientsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<DoctorDto> GetDoctorInfoAsync(string pwz)
        {
            return await doctorsServiceClient.GetDoctorByPwzAsync(pwz);
        }

        public async Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync(string pwz)
        {
            var patients = await patientsServiceClient.GetPatients();
            var appointments = await patientsServiceClient.GetAllAppointmentsByPwzAsync(pwz);

            var myPatients = new HashSet<PatientDto>();

            foreach(var appointment in appointments)
            {
                var patient = patients.ToList().Find(pat => pat.Pesel.Equals(appointment.PESEL));
                myPatients.Add(patient);
            }

            return myPatients;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(string pwz)
        {
            return await patientsServiceClient.GetAllAppointmentsByPwzAsync(pwz);
        }

        public async Task<PatientDto> GetDoctorPatientByPeselAsync(string pesel, string pwz)
        {
            var patients = await GetDoctorPatientsAsync(pwz);

            return patients.ToList().Find(pat => pat.Pesel.Equals(pesel));
        }

        public async Task<AppointmentDto> GetAppointmentDetailsAsync(int id, string pwz)
        {
            var appointments = await patientsServiceClient.GetAllAppointmentsByPwzAsync(pwz);

            var appointment = appointments.ToList().Find(app => app.AppointmentId == id);

            return appointment;
        }

        public async Task<IEnumerable<ScheduleDto>> GetDoctorScheduleAsync(string pwz)
        {
            var availabilities = await doctorsServiceClient.GetAllAvailabilitiesByPwzAsync(pwz);
            var appointments = await patientsServiceClient.GetAllAppointmentsByPwzAsync(pwz);

            var schedule = new List<ScheduleDto>();
            foreach(var availability in availabilities)
            {
                schedule.Add(new ScheduleDto(availability.Start_Date, availability.End_Date));
            }
            foreach(var appointment in appointments)
            {
                schedule.Add(new ScheduleDto(appointment.StartDate, appointment.AppointmentId));
            }
            return schedule;
        }
        public async Task AddAvailabilityAsync(AvailabilityDto availability)
        {
            var appointments = await patientsServiceClient.GetAllAppointmentsByPwzAsync(availability.PWZ);

            var reservedHours = new List<DateTime>();
            foreach(var appointment in appointments)
            {
                if ((appointment.StartDate >= availability.Start_Date) && (appointment.StartDate < availability.End_Date))
                {
                    reservedHours.Add(appointment.StartDate);
                }
            }
            reservedHours.Sort();
            var availabilities = new List<AvailabilityDto>();
            
            foreach(var hour in reservedHours)
            {
                if (hour > availability.Start_Date)
                {
                    availabilities.Add(new AvailabilityDto(availability.Start_Date, hour,availability.PWZ));
                }
                availability.Start_Date = hour + new TimeSpan(1, 0, 0);
               
            }

            if (availabilities.Count > 0)
            {
                foreach (var ava in availabilities)
                {
                    await doctorsServiceClient.AddAvailabilityAsync(ava);
                }
            }
            if (!availability.Start_Date.Equals(availability.End_Date))
            {
                await doctorsServiceClient.AddAvailabilityAsync(availability);
            }
        }
        public async Task<string> RemoveAvailabilityByIdAsync(RemoveAvailability removeAvailability)
        {
            return await doctorsServiceClient.RemoveAvailabilityByIdAsync(removeAvailability);
        }
        public async Task<string> RemoveAvailabilityBySpanAsync(AvailabilityDto removeAvailabilityBySpan)
        {
            return await doctorsServiceClient.RemoveAvailabilityBySpanAsync(removeAvailabilityBySpan);
        }

    }
}
