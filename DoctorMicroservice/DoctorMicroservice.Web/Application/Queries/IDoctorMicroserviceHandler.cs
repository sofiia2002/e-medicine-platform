namespace DoctorMicroservice.Web.Application.Queries
{
    using DoctorMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IDoctorMicroserviceHandler
    {
        Task<DoctorDto> GetDoctorInfoAsync(string pwz);
        Task<IEnumerable<ScheduleDto>> GetDoctorScheduleAsync(string pwz);
        Task<IEnumerable<PatientDto>> GetDoctorPatientsAsync(string pwz);
        Task<AppointmentDto> GetAppointmentDetailsAsync(int id, string pwz);
        Task AddAvailabilityAsync(AvailabilityDto availability);
        Task<string> RemoveAvailabilityByIdAsync(RemoveAvailability removeAvailability);
        Task<string> RemoveAvailabilityBySpanAsync(AvailabilityDto removeAvailabilityBySpan);
        Task<PatientDto> GetDoctorPatientByPeselAsync(string pesel, string pwz);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(string pwz);
    }
}
