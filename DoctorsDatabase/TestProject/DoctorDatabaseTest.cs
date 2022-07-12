namespace TestProject
{
    using DoctorsDatabase.Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Xml;

    [TestClass]
    public class DoctorDatabaseTest
    {
        private const string databaseXsdFilename = "./../../../database2.xsd";
        private const string databaseXmlFilename = "./../../../database2.xml";

        [DataTestMethod]
        [DataRow(databaseXsdFilename, "")]
        [DataRow("",databaseXmlFilename)]
        public void ReadXmlDocument_EmptyFilename_ThrowsArgumentException(string xsdFilename, string xmlFilename)
        {
            DatabaseServiceReader databaseReader = new DatabaseServiceReader();

            Action action = () => databaseReader.ReadXmlDocument(xsdFilename, xmlFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void ReadAvailabilities_DatabaseXmlFile_Returns3Availabilities()
        {
            DatabaseServiceReader databaseReader = new DatabaseServiceReader();

            XmlDocument databaseXmlDocument = databaseReader.ReadXmlDocument(databaseXsdFilename, databaseXmlFilename);

            int count = DatabaseServiceReader.ReadAvailabilities(databaseXmlDocument).Count;

            Assert.AreEqual(3, count, "Availability count should be {0} and not {1}", 3, count);
        }
    }
}
