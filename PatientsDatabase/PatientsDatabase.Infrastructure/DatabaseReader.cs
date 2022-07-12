namespace PatientsDatabase.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public class DatabaseReader
    {
        private const string databaseNamespace = "db";
        private const string databaseSchema = "http://tempuri.org/database.xsd";

        public XmlDocument ReadXmlDocument(string xsdFilename, string xmlFilename)
        {
            if (String.IsNullOrWhiteSpace(xsdFilename) || String.IsNullOrWhiteSpace(xmlFilename))
                throw new ArgumentException();

            Debug.Assert(condition: !String.IsNullOrWhiteSpace(xsdFilename) && !String.IsNullOrWhiteSpace(xmlFilename));

            using StreamReader schemaTextReader = File.OpenText(xsdFilename);

            using StreamReader dataTextReader = File.OpenText(xmlFilename);

            return this.ReadXmlDocument(schemaTextReader, dataTextReader);
        }

        public XmlDocument ReadXmlDocument(StreamReader schemaReader, StreamReader dataReader)
        {
            Debug.Assert(condition: schemaReader != null && dataReader != null);

            XmlSchema xmlSchema = this.GetXmlSchema(schemaReader);

            using XmlReader xmlReader = this.GetXmlReader(dataReader, xmlSchema);

            return this.ReadXmlDocument(xmlReader);
        }

        public XmlDocument ReadXmlDocument(XmlReader xmlReader)
        {
            Debug.Assert(condition: xmlReader != null);

            XmlDocument databaseXmlDocument = new XmlDocument();

            databaseXmlDocument.Load(xmlReader);

            return databaseXmlDocument;
        }

        private XmlSchema GetXmlSchema(StreamReader streamReader)
        {
            return XmlSchema.Read(streamReader, new ValidationEventHandler(this.SchemaValidationEventHandler));
        }

        private XmlReader GetXmlReader(StreamReader streamReader, XmlSchema xmlSchema)
        {
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

            xmlReaderSettings.Schemas.Add(xmlSchema);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(this.DataValidationEventHandler);

            return XmlReader.Create(streamReader, xmlReaderSettings);
        }

        private void SchemaValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        private void DataValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        public static List<Patient> ReadPatients(XmlDocument databaseXmlDocument)
        {
            List<Patient> patientList = new List<Patient>();

            XmlNamespaceManager xmlNamespaceManager = DatabaseReader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/db:Database/db:Patients/db:Patient");

            XmlNodeList patientXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in patientXmlNodes)
                patientList.Add(DatabaseReader.ConvertXmlElementToPatient(xmlElement, xmlNamespaceManager));

            return patientList;
        }

        public static List<Appointment> ReadAppointments(XmlDocument databaseXmlDocument)
        {
            List<Appointment> appointmentList = new List<Appointment>();

            XmlNamespaceManager xmlNamespaceManager = DatabaseReader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/db:Database/db:Appointments/db:Appointment");

            XmlNodeList appointmentXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in appointmentXmlNodes)
                appointmentList.Add(DatabaseReader.ConvertXmlElementToAppointment(xmlElement, xmlNamespaceManager));

            return appointmentList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument databaseXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(databaseXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(databaseNamespace, databaseSchema);

            return xmlNamespaceManager;
        }

        private static Patient ConvertXmlElementToPatient(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            string firstName = xmlElement.GetAttribute("FirstName");
            string lastName = xmlElement.GetAttribute("LastName");
            string pesel = xmlElement.GetAttribute("PESEL");
            return new Patient(firstName, lastName, pesel);
        }

        private static Appointment ConvertXmlElementToAppointment(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            string appointmentId = xmlElement.GetAttribute("AppointmentId");
            DateTime startDate = DateTime.Parse(xmlElement.GetAttribute("StartDate"));
            string pwz = xmlElement.GetAttribute("PWZ");
            string pesel = xmlElement.GetAttribute("PESEL");
            return new Appointment(int.Parse(appointmentId), pesel, pwz, startDate);
        }
    }
}

