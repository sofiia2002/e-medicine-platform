namespace PatientsApplicationMicroservice.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using PatientsDatabase.Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using PatientsDatabase.Domain.Services;

    [TestClass]
    public class NetworkReaderTests
    {
        private const string databaseXsdFilename = "./../../../Database.xsd";
        private const string databaseXmlFilename = "./../../../Database.xml";

        [TestMethod]
        public void ReadPatients_DatabaseXmlFile_Returns2Patients()
        {
            DatabaseReader databaseReader = new DatabaseReader();

            XmlDocument databaseXmlDocument = databaseReader.ReadXmlDocument(databaseXsdFilename, databaseXmlFilename);

            int count = DatabaseReader.ReadPatients(databaseXmlDocument).Count;

            Assert.AreEqual(2, count, "Patient count should be {0} and not {1}", 2, count);
        }

        [TestMethod]
        public void ReadPatients_DatabaseXmlFile_Returns3Appointments()
        {
            DatabaseReader databaseReader = new DatabaseReader();

            XmlDocument databaseXmlDocument = databaseReader.ReadXmlDocument(databaseXsdFilename, databaseXmlFilename);

            int count = DatabaseReader.ReadAppointments(databaseXmlDocument).Count;

            Assert.AreEqual(3, count, "Appointment count should be {0} and not {1}", 3, count);
        }
    }
}
