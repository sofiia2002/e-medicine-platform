namespace DoctorsDatabase.Infrastructure
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Schema;

    public class DatabaseServiceReader
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

        public static IList<Availability> ReadAvailabilities(XmlDocument databaseXmlDocument)
        {
            List<Availability> availabilities = new List<Availability>();

            XmlNamespaceManager xmlNamespaceManager = DatabaseServiceReader.GetXmlNamespaceManager(databaseXmlDocument);

            string xPath = String.Format("/db:Database/db:Availabilities/db:Availability");

            XmlNodeList availabilityXmlNodes = databaseXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in availabilityXmlNodes)
                availabilities.Add(DatabaseServiceReader.ConvertXmlElementToAvailability(xmlElement));

            return availabilities;
        }

        public static IList<Doctor> ReadDoctors(XmlDocument networkXmlDocument)
        {
            List<Doctor> doctors = new List<Doctor>();

            XmlNamespaceManager xmlNamespaceManager = DatabaseServiceReader.GetXmlNamespaceManager(networkXmlDocument);

            string xPath = String.Format("/db:Database/db:Doctors/db:Doctor");

            XmlNodeList linkXmlNodes = networkXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in linkXmlNodes)
                doctors.Add(DatabaseServiceReader.ConvertXmlElementToDoctor(xmlElement, xmlNamespaceManager));

            return doctors;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument databaseXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(databaseXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(databaseNamespace, databaseSchema);

            return xmlNamespaceManager;
        }

        private static Availability ConvertXmlElementToAvailability(XmlElement xmlElement)
        {

            int id = Int32.Parse(xmlElement.GetAttribute("id"));
            DateTime startDate = DateTime.Parse(xmlElement.GetAttribute("startDate"));
            DateTime endDate = DateTime.Parse(xmlElement.GetAttribute("endDate"));
            string pwz = xmlElement.GetAttribute("pwz");

            return new Availability(id, startDate, endDate, pwz);
        }

        private static Doctor ConvertXmlElementToDoctor(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            string firstName = xmlElement.GetAttribute("firstName");
            string lastName = xmlElement.GetAttribute("lastName");
            string pwz = xmlElement.GetAttribute("pwz");
            var specializations = new List<string>();

            XmlElement specializationsXmlElement = xmlElement.SelectSingleNode("db:Specializations", xmlNamespaceManager) as XmlElement;

            XmlNodeList specializationNodes = specializationsXmlElement.SelectNodes("db:Specialization", xmlNamespaceManager);

            foreach (XmlElement specializationNode in specializationNodes)
                specializations.Add(specializationNode.GetAttribute("specialization"));

            return new Doctor(firstName, lastName, pwz, specializations);
        }
    }
}
