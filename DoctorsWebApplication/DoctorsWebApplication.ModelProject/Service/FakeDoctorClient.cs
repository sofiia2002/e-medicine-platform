namespace DoctorsWebApplication.ModelProject
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;
    using System.Linq;

    class FakeDoctorClient
    {

        private List<ScheduleData> schedule = new List<ScheduleData>
            {
                new ScheduleData(new DateTime(2021,5,30,15,0,0), new DateTime(2021,5,30,16,0,0), "Availability", 0),
                new ScheduleData(new DateTime(2021,6,1,15,0,0), new DateTime(2021,6,1,16,0,0), "Availability", 0)
            };

        private List<AppointmentData> appointments = new List<AppointmentData>()
            {
                new AppointmentData(1, "12345678910", "1234567", new DateTime(2021,5,29,15,0,0)),
                new AppointmentData(2, "34567890123", "1234567", new DateTime(2021,5,28,15,0,0))
            };

        private List<PatientData> patients = new List<PatientData>
            {
                new PatientData() { FirstName = "Sonya", LastName = "Levchenko", PESEL = "12345678910" },
                new PatientData() { FirstName = "Marcin", LastName = "Ziolkowski", PESEL = "34567890123" }
            };

        public async Task<List<ScheduleData>> GetSchedule(string pwz)
        {
            await Task.Delay(10);
            return this.schedule;
        }

        public async Task<List<AppointmentData>> GetAppointments(string pwz)
        {
            await Task.Delay(10);
            return this.appointments;
        }

        public async Task<List<PatientData>> GetMyPatients(string pwz)
        {
            await Task.Delay(10);
            return this.patients;
        }

        public async Task<AppointmentData> GetAppointmentDetails(int id, string pwz)
        {
            await Task.Delay(10);
            return this.appointments.Find(x => x.AppointmentId == id && x.PWZ == pwz);
        }

        public async Task<PatientData> GetPatientDetails(string pesel, string pwz)
        {
            await Task.Delay(10);
            return this.patients.Find(x => x.PESEL == pesel);
        }


        public async Task CreateAvailability(AvailabilityDto newAvailability)
        {
            this.schedule.Add(new ScheduleData(newAvailability.Start_Date, newAvailability.End_Date, "Availability", 0));
            await Task.Delay(10);
        }

        public async Task DeleteAvailability(AvailabilityData availabilityToRemove)
        {
            var schedule = this.schedule.Find(x => x.Start_Date == availabilityToRemove.Start_Date);
            this.schedule.Remove(schedule);
            await Task.Delay(10);
        }
    }
}
