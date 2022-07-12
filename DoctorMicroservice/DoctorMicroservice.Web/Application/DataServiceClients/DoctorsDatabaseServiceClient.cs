namespace DoctorMicroservice.Web.Application.DataServiceClients
{
    using DoctorMicroservice.Web.Application.Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class DoctorsDatabaseServiceClient : IDoctorsDatabaseServiceClient
    {
        public IHttpClientFactory clientFactory;
        public DoctorsDatabaseServiceClient(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }


        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-doctor-by-pwz?pwz=" + pwz);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DoctorDto>(responseStream);
        }

        public async Task<IEnumerable<AvailabilityWithIdDto>> GetAllAvailabilitiesByPwzAsync(string pwz)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://doctor-database:80/get-availabilities-by-pwz?pwz=" + pwz);
            request.Headers.Add("Accept", "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var responseStream = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<AvailabilityWithIdDto>>(responseStream);
        }

        public async Task<string> AddAvailabilityAsync(AvailabilityDto availability)
        {
            string availabilityString = JsonConvert.SerializeObject(availability);
            var stringContent = new StringContent(availabilityString, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var response = await client.PostAsync($"http://doctor-database:80/add-availability", stringContent);

            return response.StatusCode.ToString();
        }

        public async Task<string> RemoveAvailabilityByIdAsync(RemoveAvailability toRemove)
        {
            string toRemoveString = JsonConvert.SerializeObject(toRemove);
            var stringContent = new StringContent(toRemoveString, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://doctor-database:80/remove-availability"),
                Content = stringContent
            };

            var response = await client.SendAsync(request);

            return response.StatusCode.ToString();
        }

        public async Task<string> RemoveAvailabilityBySpanAsync(AvailabilityDto removeAvailabilityBySpan)
        {
            string toRemoveString = JsonConvert.SerializeObject(removeAvailabilityBySpan);
            var stringContent = new StringContent(toRemoveString, Encoding.UTF8, "application/json");

            var client = clientFactory.CreateClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"http://doctor-database:80/remove-availability-span"),
                Content = stringContent
            };

            var response = await client.SendAsync(request);

            return response.StatusCode.ToString();
        }

    }
}
