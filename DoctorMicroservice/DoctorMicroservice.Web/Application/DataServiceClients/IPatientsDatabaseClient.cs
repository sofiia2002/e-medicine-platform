namespace DoctorMicroservice.Web.Application.DataServiceClients
{
    using DoctorMicroservice.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPatientsDatabaseClient
    {
        Task<IEnumerable<AppointmentDto>> GetAllAppointmentsByPwzAsync(string pwz);
        Task<IEnumerable<PatientDto>> GetPatients();
    }
}
