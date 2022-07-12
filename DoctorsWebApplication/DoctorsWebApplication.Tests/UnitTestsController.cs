namespace DoctorsWebApplication.Tests
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DoctorsWebApplication.ReactServer.Controllers;
    using DoctorsWebApplication.ModelProject;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
    using System;

    [TestClass]
    public class UnitTestController
    {
        [TestMethod]
        public async Task DeleteDoctorAvailability_AvailabilitiesHas1Element()
        {
            var model = new Model(new EventDispatcher());
            var logger = new Logger() as ILogger<DoctorsController>;
            var controller = new DoctorsController(logger, model);
            var availabilityToDelete = new AvailabilityData(0, new DateTime(2021, 5, 30, 15, 0, 0), new DateTime(2021, 5, 30, 16, 0, 0), "1234567");
            await Task.Run(()=>controller.GetAvailabilities());
            await Task.Delay(20);
            var oldAvailabilitiesCount = model.Availabilities.Count;
            await Task.Run(() => controller.DeleteDoctorAvailability(availabilityToDelete));
            await Task.Delay(20);
            await Task.Run(() => controller.GetAvailabilities());
            await Task.Delay(20);
            Assert.AreEqual(model.Availabilities.Count, oldAvailabilitiesCount-1, "There should be 1, not {0} availabilities on the list", model.Availabilities.Count);
        }

        [TestMethod]
        public async Task AddDoctorAvailability_AvailabilitiesContain()
        {
            var model = new Model(new EventDispatcher());
            var logger = new Logger() as ILogger<DoctorsController>;
            var controller = new DoctorsController(logger, model);
            var availabilityToAdd = new AvailabilityData(0, new DateTime(2021, 5, 30, 17, 0, 0), new DateTime(2021, 5, 30, 18, 0, 0), "1234567");
            await Task.Run(() => controller.GetAvailabilities());
            await Task.Delay(20);
            var newAvailabilitiesCount = model.Availabilities.Count + 1;
            await Task.Run(() => controller.AddDoctorAvailability(availabilityToAdd));
            await Task.Delay(20);
            Assert.AreEqual(model.Availabilities.Count, newAvailabilitiesCount, "There should be 3, not {0} availabilities on the list", model.Availabilities.Count);
        }
    }
}
