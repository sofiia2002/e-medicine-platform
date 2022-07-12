namespace PatientsDatabase.Infrastructure
{
    using System.Xml;
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public class DatabaseWriter
    {
        private const string databaseSchema = "http://tempuri.org/database.xsd";
        private const string databaseXml = "Database.xml";

        Database mydatabase = new Database();

        private static XmlNode ConvertAppointmentToXmlElement(Appointment appointmnet, XmlDocument xmlDoc)
        {
            XmlNode appointmentNode = xmlDoc.CreateElement("db", "Appointment", databaseSchema);

            XmlAttribute appointmentIdAttribute = xmlDoc.CreateAttribute("AppointmentId");
            XmlAttribute dateStartAttribute = xmlDoc.CreateAttribute("StartDate");
            XmlAttribute peselAttribute = xmlDoc.CreateAttribute("PESEL");
            XmlAttribute pwzAttribute = xmlDoc.CreateAttribute("PWZ");

            appointmentIdAttribute.Value = appointmnet.Id.ToString();
            dateStartAttribute.Value = appointmnet.StartDate.ToString("yyyy-MM-ddTHH:mm:ss");
            peselAttribute.Value = appointmnet.PESEL;
            pwzAttribute.Value = appointmnet.PWZ;

            appointmentNode.Attributes.Append(appointmentIdAttribute);
            appointmentNode.Attributes.Append(dateStartAttribute);
            appointmentNode.Attributes.Append(pwzAttribute);
            appointmentNode.Attributes.Append(peselAttribute);

            return appointmentNode;
        }

        public static void AddAppointment(Appointment appointment)
        {
            XmlDocument document = new XmlDocument();
            XmlNode appointmentNode = DatabaseWriter.ConvertAppointmentToXmlElement(appointment, document);
            document.Load( databaseXml );
            document.DocumentElement.LastChild.AppendChild(appointmentNode);
            document.Save( databaseXml );
        }

        public static void RemoveAppointment(string id)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(databaseXml);

            string appointmentIdToRemove = id;

            if (xmlDoc.DocumentElement != null)
            {
                for (var i = 0; i < xmlDoc.DocumentElement.LastChild.ChildNodes.Count; ++i)
                {
                    var appointmentId = xmlDoc.DocumentElement.LastChild.ChildNodes[i];

                    if (appointmentId == null || (appointmentId.Attributes["AppointmentId"].Value != appointmentIdToRemove))
                    {
                        continue;
                    }

                    var nodeToRemove = xmlDoc.DocumentElement.LastChild.ChildNodes[i];

                    if (nodeToRemove.ParentNode != null)
                    {
                        nodeToRemove.ParentNode.RemoveChild(nodeToRemove);
                    }

                    break;
                }
            }
            xmlDoc.Save(databaseXml);
        }

    }
}
