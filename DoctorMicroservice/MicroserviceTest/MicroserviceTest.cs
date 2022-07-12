namespace MicroserviceTest
{
    using DoctorMicroservice.Web.Application.DataServiceClients;
    using DoctorMicroservice.Web.Application.Queries;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class MicroserviceTest
    {
        public static IDoctorsDatabaseServiceClient doctorsClient = new DoctorDatabaseServiceClientMock();
        public static IPatientsDatabaseClient patientsClient = new PatientsDatabaseServiceClientMock();

        [TestMethod]
        public async Task GetDoctorPatientsAsync_ReturnsOnlyDoctorsPatients()
        {
            var queryHandler = new DoctorMicroServiceQueryHandler(doctorsClient, patientsClient);
            var patients = await queryHandler.GetDoctorPatientsAsync("1234568");
            int count = patients.Count();
            Assert.AreEqual(count, 1, "Doctor has {0} Patient, but method returned {1}", 1, count);
        }

        [TestMethod]
        public async Task GetDoctorPatientsAsync_ReturnsPatientsWithoutDuplicates()
        {
            var queryHandler = new DoctorMicroServiceQueryHandler(doctorsClient, patientsClient);
            var patients = await queryHandler.GetDoctorPatientsAsync("1234567");
            var condition = patients.GroupBy(n => n).Any(c => c.Count() > 1);
            Assert.AreEqual(condition, false, "Method has returned IEnumerable with duplicates");
        }
    }
}
