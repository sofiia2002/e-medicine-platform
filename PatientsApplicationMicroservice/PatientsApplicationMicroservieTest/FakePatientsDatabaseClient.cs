namespace PatientsApplicationMicroservice.Test

{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PatientsApplicationMicroservice.Web.Application.DataServiceClients;
    using PatientsApplicationMicroservice.Web.Application.Dtos;

    class FakePatientsDatabaseClient : IPatientsDatabaseClient
    {
        public async Task<IEnumerable<AppointmentDto>> GetPatientsAppointments(string pesel)
        {
            await Task.Delay(500);
            return new List<AppointmentDto>() { new AppointmentDto(11, "34567890123", "1234578", new DateTime(2021, 03, 18, 08, 00, 00)), new AppointmentDto(14, "34567890123", "1234578", new DateTime(2021, 03, 18, 10, 00, 00)), new AppointmentDto(17, "34567890123", "1234578", new DateTime(2021, 03, 18, 11, 00, 00)) };
        }

        public async Task AddAppointment(RawAppointmentDto rawAppointmentDto)
        {
            await Task.Delay(500);
        }


        public async Task DeleteAppointment(int id)
        {
            await Task.Delay(500);
        }
    }
}
