namespace DoctorsWebApplication.ModelProject
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;

    class DoctorClient
    {
        public async Task<List<ScheduleData>> GetSchedule(string pwz)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5053/doctor-schedule?pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ScheduleData>>(responseStream);
        }

        public async Task<List<AppointmentData>> GetAppointments(string pwz)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5053/appointments?pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AppointmentData>>(responseStream);

        }

        public async Task<List<PatientData>> GetMyPatients(string pwz)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5053/my-patients?pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PatientData>>(responseStream);

        }

        public async Task<AppointmentData> GetAppointmentDetails(int id, string pwz)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5053/appointment-details?pwz={pwz}&id={id}");
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AppointmentData>(responseStream);

        }

        public async Task<PatientData> GetPatientDetails(string pesel, string pwz)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:5053/patient?pesel={pesel}&pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PatientData>(responseStream);

        }


        public async Task CreateAvailability(AvailabilityDto newAvailability)
        {
            var jsonAvailability = JsonConvert.SerializeObject(newAvailability);

            var dataAvailability = new StringContent(jsonAvailability, Encoding.UTF8, "application/json");
            var ulrAvailability = "http://localhost:5053/add-availability";
            var client = new HttpClient();
            var responseAvailability = await client.PostAsync(ulrAvailability, dataAvailability);
        }

        public async Task DeleteAvailability(AvailabilityData availabilityToRemove)
        {
            var availabilityDto = new AvailabilityDto(availabilityToRemove.Start_Date, availabilityToRemove.End_Date, availabilityToRemove.Pwz);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:5053/remove-availability-by-span"),
                Content = new StringContent(JsonConvert.SerializeObject(availabilityDto), Encoding.UTF8, "application/json")
            };
            var client = new HttpClient();
            var responseAvailability = await client.SendAsync(request);
        }
    }
}
