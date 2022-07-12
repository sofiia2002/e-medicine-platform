namespace DoctorMicroservice.Web.Application.DataServiceClients
{
    using DoctorMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorsDatabaseServiceClient
    {
        Task<DoctorDto> GetDoctorByPwzAsync(string pwz);
        Task<IEnumerable<AvailabilityWithIdDto>> GetAllAvailabilitiesByPwzAsync(string pwz);
        Task<string> AddAvailabilityAsync(AvailabilityDto availability);
        Task<string> RemoveAvailabilityByIdAsync(RemoveAvailability toRemove);
        Task<string> RemoveAvailabilityBySpanAsync(AvailabilityDto removeAvailabilityBySpan);
    }
}
