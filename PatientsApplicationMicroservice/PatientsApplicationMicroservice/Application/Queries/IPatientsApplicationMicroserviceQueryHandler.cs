namespace PatientsApplicationMicroservice.Web.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PatientsApplicationMicroservice.Web.Application.Dtos;

    public interface IPatientsApplicationMicroserviceQueryHandler
    {
        Task<List<AppointmentDto>> GetPatientsAppointmentsAsync(string pesel);
        Task<List<AvailabilityDto>> GetDoctorScheduleAsync(string pwz);
        Task<List<DoctorDto>> GetAllDoctorsAsync();
        Task<List<AvailabilityDto>> GetAllAvailabilitiesAsync();
        Task<List<DoctorDto>> GetDoctorsBySpecializationAsync(string id);
        Task<DoctorDto> GetDoctorByPwzAsync(string pwz);
        Task AddAppointmentAsync(RawAppointmentDto rawAppointmentDto, string pwzRaw, DateTime startDateRaw);
        Task DeleteAppointmentAsync(int id, string pwz, DateTime startDate);
        Task<List<DoctorDto>> GetMyDoctorsAsync(string pesel);
    }
}
