namespace PatientsApplicationMicroservice.Web.Application.DataServiceClients
{
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Web;

    public class PatientsDatabaseClient : IPatientsDatabaseClient
    {
        public IHttpClientFactory clientFactory;
        public PatientsDatabaseClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<IEnumerable<AppointmentDto>> GetPatientsAppointments(string pesel)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://data_microservice:80/get-appointments-by-pesel?pesel={pesel}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<AppointmentDto>>(responseStream, options);
        }

        public async Task AddAppointment(RawAppointmentDto rawAppointmentDto)
        {

            var jsonAppointment = JsonConvert.SerializeObject(rawAppointmentDto);
            var dataAppointment = new StringContent(jsonAppointment, Encoding.UTF8, "application/json");
            var urlAppointment = "http://data_microservice:80/post-appointment/";

            using var clientAppointment = new HttpClient();

            var responseAppointment = await clientAppointment.PostAsync(urlAppointment, dataAppointment);
        }

        
        public async Task DeleteAppointment(int id)
        {
            var requestToPatientDatabase = new HttpRequestMessage(HttpMethod.Delete,
            $"http://data_microservice:80/delete-appointment?id={id}");

            requestToPatientDatabase.Headers.Add("Accept", "application/json");

            var clientToPatientDatabase = clientFactory.CreateClient();
            var responseToPatientDatabase = await clientToPatientDatabase.SendAsync(requestToPatientDatabase);

            using var responseStreamToPatientDatabase = await responseToPatientDatabase.Content.ReadAsStreamAsync();
        }
    }
}
