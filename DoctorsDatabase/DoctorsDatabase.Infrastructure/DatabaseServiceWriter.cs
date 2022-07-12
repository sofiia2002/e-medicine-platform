namespace DoctorsDatabase.Infrastructure
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    public class DatabaseServiceWriter
    {
        private const string databaseNamespace = "db";
        private const string databaseSchema = "http://tempuri.org/database.xsd";

        public static void SaveAll(List<Availability> availabilities, List<Doctor> doctors)
        {

            XmlDocument xmlDoc = new XmlDocument();

            XmlDeclaration xmldecl;
            xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmldecl);

            XmlNode rootNode = xmlDoc.CreateElement("db", "Database", databaseSchema);
            XmlAttribute attribute = xmlDoc.CreateAttribute("xmlns:db");
            attribute.Value = "http://tempuri.org/database.xsd";
            rootNode.Attributes.Append(attribute);
            XmlAttribute attribute2 = xmlDoc.CreateAttribute("modified");
            attribute2.Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            rootNode.Attributes.Append(attribute2);
            xmlDoc.AppendChild(rootNode);

            XmlNode availabilitiesNode = xmlDoc.CreateElement("db", "Availabilities", databaseSchema);
            rootNode.AppendChild(availabilitiesNode);

            foreach (var availability in availabilities)
            {
                XmlNode availabilityNode = xmlDoc.CreateElement("db", "Availability", databaseSchema);
                attribute = xmlDoc.CreateAttribute("id");
                attribute.Value = availability.Id.ToString();
                availabilityNode.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("startDate");
                attribute.Value = availability.Start_Date.ToString("yyyy-MM-ddTHH:mm:ss");
                availabilityNode.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("endDate");
                attribute.Value = availability.End_Date.ToString("yyyy-MM-ddTHH:mm:ss");
                availabilityNode.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("pwz");
                attribute.Value = availability.PWZ.ToString();
                availabilityNode.Attributes.Append(attribute);

                availabilitiesNode.AppendChild(availabilityNode);
            }

            XmlNode doctorsNode = xmlDoc.CreateElement("db", "Doctors", databaseSchema);
            rootNode.AppendChild(doctorsNode);

            foreach (var doctor in doctors)
            {
                XmlNode doctorNode = xmlDoc.CreateElement("db", "Doctor", databaseSchema);
                attribute = xmlDoc.CreateAttribute("firstName");
                attribute.Value = doctor.FirstName.ToString();
                doctorNode.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("lastName");
                attribute.Value = doctor.LastName.ToString();
                doctorNode.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("pwz");
                attribute.Value = doctor.PWZ.ToString();
                doctorNode.Attributes.Append(attribute);

                XmlNode specializationsNode = xmlDoc.CreateElement("db", "Specializations", databaseSchema);
                doctorNode.AppendChild(specializationsNode);

                foreach(var specialization in doctor.Specializations)
                {
                    XmlNode specializationNode = xmlDoc.CreateElement("db", "Specialization", databaseSchema);
                    attribute = xmlDoc.CreateAttribute("specialization");
                    attribute.Value = specialization;
                    specializationNode.Attributes.Append(attribute);

                    specializationsNode.AppendChild(specializationNode);
                }

                doctorsNode.AppendChild(doctorNode);
            }

            xmlDoc.Save("database.xml");
        }
    }
}
