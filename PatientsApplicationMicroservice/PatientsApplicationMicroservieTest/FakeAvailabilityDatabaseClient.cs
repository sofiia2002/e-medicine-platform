namespace PatientsApplicationMicroservice.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PatientsApplicationMicroservice.Web.Application.DataServiceClients;
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    class FakeAvailabilityDatabaseClient : IAvailabilityDatabaseClient
    {

        public async Task<IEnumerable<AvailabilityDto>> GetDoctorScheduleAsync(string pwz)
        {
            await Task.Delay(1000);

            return new List<AvailabilityDto>();
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            await Task.Delay(1000);
            return new List<DoctorDto>();
        }

        public async Task CancelAvailability(string pwzRaw, DateTime startDateRaw)
        {
            await Task.Delay(1000);
        }

        public async Task DeleteAvailability(string pwzRaw, DateTime startDateRaw)
        {
            await Task.Delay(1000);
        }

        public async Task<IEnumerable<AvailabilityDto>> GetAllAvailabilitiesAsync()
        {
            await Task.Delay(1000);
            return new List<AvailabilityDto>();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string id)
        {
            await Task.Delay(1000);
            return new List<DoctorDto>();
        }

        public async Task<DoctorDto> GetDoctorByPwzAsync(string pwz)
        {
            await Task.Delay(1000);
            return new DoctorDto("Agata", "Serowska", "1234578", new List<string> { "5", "3", "4" });
        }
    }
}
