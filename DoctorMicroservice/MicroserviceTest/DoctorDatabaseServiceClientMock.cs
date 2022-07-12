namespace MicroserviceTest
{
    using DoctorMicroservice.Web.Application.DataServiceClients;
    using DoctorMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DoctorDatabaseServiceClientMock : IDoctorsDatabaseServiceClient
    {
        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {
            await Task.Delay(500);
            return new DoctorDto();
        }
        public async Task<IEnumerable<AvailabilityWithIdDto>> GetAllAvailabilitiesByPwzAsync(string pwz)
        {
            await Task.Delay(500);
            return new List<AvailabilityWithIdDto>();
        }
        public async Task<string> AddAvailabilityAsync(AvailabilityDto availability)
        {
            await Task.Delay(500);
            return "200";
        }
        public async Task<string> RemoveAvailabilityByIdAsync(RemoveAvailability toRemove)
        {
            await Task.Delay(500);
            return "200";
        }
        public async Task<string> RemoveAvailabilityBySpanAsync(AvailabilityDto removeAvailabilityBySpan)
        {
            await Task.Delay(500);
            return "200";
        }
    }
}
