namespace DoctorsClientApplication.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DoctorsClientApplication.Model;
    using DoctorsClientApplication.Utilities;
    using DoctorsClientApplication.Controller;

    [TestClass]
    public class UnitTestModel
    {
        [TestMethod]
        public async Task LoadPatients_Load2Patients()
        {
            var model = new Model(new EventDispatcher());

            var patients = new List<PatientData> 
            { 
                new PatientData() { FirstName = "Sonya", LastName = "Levchenko", PESEL = "12345678910" },
                new PatientData() { FirstName = "Marcin", LastName = "Ziolkowski", PESEL = "34567890123" }
            };

            await Task.Run(()=>model.LoadPatients());
            await Task.Delay(50);

            Assert.AreEqual(patients.Count, model.Patients.Count, "There is {0} patients in model and {1} patients in data set", model.Patients.Count, patients.Count);
        }

        [TestMethod]
        public async Task LoadAppointmentDetails_ShowsCorrectPatientPesel()
        {
            var model = new Model(new EventDispatcher());
            var patient = new PatientData() { FirstName = "Sonya", LastName = "Levchenko", PESEL = "12345678910" };
            model.SelectedAppointment = new AppointmentData(1, "12345678910", "1234567", new DateTime(2021, 5, 29, 15, 0, 0));
            await Task.Delay(50);
            await Task.Run(()=>model.LoadAppointmentDetails());
            await Task.Delay(150);

            Assert.AreEqual(patient.PESEL, model.PatientDetails.PESEL, "Patient should have PESEL {0}, not {1}", patient.PESEL, model.PatientDetails.PESEL);
        }
    }
}