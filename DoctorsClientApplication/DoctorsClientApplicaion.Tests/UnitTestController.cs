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
    public class UnitTestController
    {
        [TestMethod]
        public async Task ShowAppointmentPageCommand_AppointmentPageState()
        {
            var controller = ControllerFactory.GetController(new EventDispatcher());
            var obj = new object();
            await Task.Delay(50);
            controller.ShowAppointmentPageCommand.Execute(obj);
            await Task.Delay(50);
            Assert.AreEqual(controller.CurrentState, ApplicationState.AppointmentPage, "Application state should be {0}, not {1}", ApplicationState.AppointmentPage.ToString(), controller.CurrentState.ToString());
        }

        [TestMethod]
        public async Task ShowAppointmentPageCommand_DoctorScheduleState()
        {
            var controller = ControllerFactory.GetController(new EventDispatcher());
            var obj = new object();
            await Task.Delay(50);
            controller.ShowDoctorScheduleCommand.Execute(obj);
            await Task.Delay(50);
            Assert.AreEqual(controller.CurrentState, ApplicationState.DoctorSchedule, "Application state should be {0}, not {1}", ApplicationState.DoctorSchedule.ToString(), controller.CurrentState.ToString());
        }
    }
}