namespace DoctorMicroservice.Web.Application.DataServiceClients
{
    using DoctorMicroservice.Web.Application.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class PatientsDatabaseClient : IPatientsDatabaseClient
    {
        public IHttpClientFactory clientFactory;
        public PatientsDatabaseClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsByPwzAsync(string pwz)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://data_microservice:80/get-appointments-by-pwz?pwz=" + pwz);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<AppointmentDto>>(responseStream);
        }

        public async Task<IEnumerable<PatientDto>> GetPatients()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://data_microservice:80/get-patients");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<PatientDto>>(responseStream);
        }
    }
}
