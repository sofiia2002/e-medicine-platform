using DoctorMicroservice.Web.Application.DataServiceClients;
using DoctorMicroservice.Web.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceTest
{
    public class PatientsDatabaseServiceClientMock : IPatientsDatabaseClient
    {
        public List<AppointmentDto> appointments = new List<AppointmentDto>() { new AppointmentDto() { AppointmentId=1, PESEL= "12345678900", PWZ="1234567", StartDate=new DateTime(2021,8,10,12,0,0) }, new AppointmentDto() { AppointmentId = 2, PESEL = "12345678900", PWZ = "1234567", StartDate = new DateTime(2021, 8, 20, 16, 0, 0) }, new AppointmentDto() { AppointmentId = 1, PESEL = "12345678911", PWZ = "1234567", StartDate = new DateTime(2021, 8, 10, 16, 0, 0) }, new AppointmentDto() { AppointmentId = 1, PESEL = "12345678922", PWZ = "1234568", StartDate = new DateTime(2021, 8, 10, 12, 0, 0) } };

        public List<PatientDto> patients = new List<PatientDto>() { new PatientDto() { FirstName="Andrzej", LastName="Najman", Pesel="12345678900"}, new PatientDto() { FirstName = "Miłosz", LastName = "Chrabek", Pesel = "12345678911" }, new PatientDto() { FirstName = "Birak", LastName = "Mirak", Pesel = "12345678922" } };

        public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsByPwzAsync(string pwz)
        {
            await Task.Delay(500);
            return appointments.Where(app => app.PWZ.Equals(pwz));
        }
        public async Task<IEnumerable<PatientDto>> GetPatients()
        {
            await Task.Delay(500);
            return patients;
        }
    }
}
