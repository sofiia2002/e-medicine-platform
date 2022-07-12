namespace PatientsApplicationMicroservice.Test

{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PatientsApplicationMicroservice.Web.Application.DataServiceClients;
    using PatientsApplicationMicroservice.Web.Application.Dtos;
    using PatientsApplicationMicroservice.Web.Application.Queries;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class PatientsMicroserviceTest
    {
        public static IPatientsDatabaseClient fakePatientsDatabaseClient = new FakePatientsDatabaseClient();
        public static IAvailabilityDatabaseClient fakeAvailabilityDatabaseClient = new FakeAvailabilityDatabaseClient();

        [TestMethod]
        public async Task GetMyDoctors_FirstDataSet_ReturnCorrectAmmount()
        {
            var testMicroserviceQueryHandler = new PatientsApplicationMicroserviceQueryHandler(fakePatientsDatabaseClient, fakeAvailabilityDatabaseClient);
            var doctors = await testMicroserviceQueryHandler.GetMyDoctorsAsync("34567890123");
            int doctorsCount = doctors.Count();
            Assert.IsTrue(doctorsCount == 1, $"There are {doctorsCount} of doctors returned instead of {1}");
        }

        [TestMethod]
        public async Task GetMyDoctors_FirstDataSet_ReturnCorrectDoctors()
        {
            var testMicroserviceQueryHandler = new PatientsApplicationMicroserviceQueryHandler(fakePatientsDatabaseClient, fakeAvailabilityDatabaseClient);
            var doctorsFromQuery = await testMicroserviceQueryHandler.GetMyDoctorsAsync("34567890123");
            Console.WriteLine(doctorsFromQuery);
            var patientDoctors = new List<DoctorDto> { new DoctorDto("Agata", "Serowska", "1234578", new List<string> { "5", "3", "4" }) };
            foreach (DoctorDto doctor in doctorsFromQuery)
            {
                Assert.IsTrue(patientDoctors.Count(x=>x.PWZ == doctor.PWZ)==1, $"The function returned the wrong doctors");
            }
        }
    }

}
