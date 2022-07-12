namespace PatientsApplicationMicroservice.Web.Application.DataServiceClients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    using System;

    public interface IAvailabilityDatabaseClient
    {
        Task<IEnumerable<AvailabilityDto>> GetDoctorScheduleAsync(string pwz);
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task CancelAvailability(string pwzRaw, DateTime startDateRaw);
        Task DeleteAvailability(string pwzRaw, DateTime startDateRaw);
        Task<IEnumerable<AvailabilityDto>> GetAllAvailabilitiesAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecializationAsync(string id);
        Task<DoctorDto> GetDoctorByPwzAsync(string pwz);
    }
}
