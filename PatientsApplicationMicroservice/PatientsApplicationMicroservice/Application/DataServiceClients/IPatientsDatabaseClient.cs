namespace PatientsApplicationMicroservice.Web.Application.DataServiceClients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PatientsApplicationMicroservice.Web.Application.Dtos;

    public interface IPatientsDatabaseClient
    {
        Task<IEnumerable<AppointmentDto>> GetPatientsAppointments(string pesel);
        Task AddAppointment(RawAppointmentDto rawAppointmentDto);
        Task DeleteAppointment(int id);
    }
}
