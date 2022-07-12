namespace PatientsDatabase.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    using PatientsDatabase.Domain.Services;
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public class Database : IDatabase
    {
        private static XmlDocument databaseXmlDocument;

        private static readonly List<Patient> Patients;

        private static readonly List<Appointment> Appointments;

        private static readonly object databaseLock = new object();

        private const string networkXsdFilename = "Database.xsd";
        private const string networkXmlFilename = "Database.xml";

        static Database()
        {
            lock (Database.databaseLock)
            {
                DatabaseReader networkReader = new DatabaseReader();

                Database.databaseXmlDocument = networkReader.ReadXmlDocument(networkXsdFilename, networkXmlFilename);

                Database.Appointments = DatabaseReader.ReadAppointments(databaseXmlDocument);

                Database.Patients = DatabaseReader.ReadPatients(databaseXmlDocument);
            }
        }

        public Database()
        {
        }

        public Patient[] GetPatients()
        {
            lock (Database.databaseLock)
            {
                return Database.Patients.ToArray();
            }
        }

        public Appointment[] GetAppointments()
        {
            lock (Database.databaseLock)
            {
                return Database.Appointments.ToArray();
            }
        }

        public Appointment[] GetAppointmentsByPwz(string pwz)
        {
            lock (Database.databaseLock)
            {
                return Database.Appointments.Where(appointemnt => appointemnt.PWZ == pwz).ToArray();
            }
        }

        public Appointment[] GetAppointmentsByPesel(string pesel)
        {
            lock (Database.databaseLock)
            {
                return Database.Appointments.Where(appointemnt => appointemnt.PESEL == pesel).ToArray();
            }
        }

        public void AddAppointment(Appointment appointment)
        {
            lock (Database.databaseLock)
            {
                Database.Appointments.Add(appointment);
                DatabaseWriter.AddAppointment(appointment);
            }
        }

        public void DeleteAppointment(int id)
        {
            lock (Database.databaseLock)
            {
                Appointment appointmentToRemove = Database.Appointments.Find(appointment=>appointment.Id==id);
                Database.Appointments.Remove(appointmentToRemove);
                DatabaseWriter.RemoveAppointment(id.ToString());
            }
        }
    }
}
