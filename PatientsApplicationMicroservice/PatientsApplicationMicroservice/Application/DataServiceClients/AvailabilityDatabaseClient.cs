namespace PatientsApplicationMicroservice.Web.Application.DataServiceClients
{
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Text;

    public class AvailabilityDatabaseClient : IAvailabilityDatabaseClient
    {
        public IHttpClientFactory clientFactory;
        public AvailabilityDatabaseClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
        
        public async Task<IEnumerable<AvailabilityDto>> GetDoctorScheduleAsync(string pwz)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-availabilities-by-pwz?pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<AvailabilityDto>>(responseStream, options);
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-doctors");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public async Task CancelAvailability(string pwzRaw, DateTime startDateRaw)
        {
            var rawAvailabilityDto = new RawAvailabilityDto { PWZ = pwzRaw, StartDate = startDateRaw };

            string toRemoveString = JsonConvert.SerializeObject(rawAvailabilityDto);

            var stringToDoctorsDatabase = new StringContent(toRemoveString, Encoding.UTF8, "application/json");
            var clientToDoctorsDatabase = clientFactory.CreateClient();

            var requestToDoctorsDatabase = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://doctor-database:80/cancel-appointment-date"),
                Content = stringToDoctorsDatabase
            };

            var responseToDoctorsDatabase = await clientToDoctorsDatabase.SendAsync(requestToDoctorsDatabase);
        }

        public async Task DeleteAvailability(string pwzRaw, DateTime startDateRaw)
        {
            var rawAvailabilityDto = new RawAvailabilityDto { PWZ = pwzRaw, StartDate = startDateRaw };

            string toReserveString = JsonConvert.SerializeObject(rawAvailabilityDto);

            var stringContent = new StringContent(toReserveString, Encoding.UTF8, "application/json");
            var clientAvailability = clientFactory.CreateClient();
            var requestAvailability = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://doctor-database:80/reserve-appointment-date"),
                Content = stringContent
            };
            var responseAvailability = await clientAvailability.SendAsync(requestAvailability);
        }

        public async Task<IEnumerable<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-availabilities");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<AvailabilityDto>>(responseStream, options);
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-doctors-by-specialization?specialization={id}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<DoctorDto>>(responseStream, options);
        }

        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-doctor-by-pwz?pwz={pwz}");
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return await System.Text.Json.JsonSerializer.DeserializeAsync<DoctorDto>(responseStream, options);
        }
    }
}
