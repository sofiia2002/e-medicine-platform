namespace PatientsDatabase.Test
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System;

    using PatientsDatabase.Domain.Services;
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;

    public class FakeDatabase : IDatabase
    {

        private static readonly List<Patient> Patients;

        private static readonly List<Appointment> Appointments;

        static FakeDatabase()
        {
            FakeDatabase.Appointments = new List<Appointment>() { new Appointment(1, "12345678910", "1234578", new DateTime(2021, 5, 31, 12, 0, 0)), new Appointment(1, "34567890123", "1234578", new DateTime(2021, 6, 9, 11, 0, 0)), new Appointment(1, "12345678910", "1234578", new DateTime(2021, 5, 27, 16, 0, 0)) };
            FakeDatabase.Patients = new List<Patient>() { new Patient("Sonya", "Levchenko", "12345678910"), new Patient("Marcin", "Ziolkowski", "34567890123") };
        }

        public FakeDatabase()
        {
        }

        public Patient[] GetPatients()
        {
            return FakeDatabase.Patients.ToArray();
        }

        public Appointment[] GetAppointments()
        {
            return FakeDatabase.Appointments.ToArray();
        }

        public Appointment[] GetAppointmentsByPwz(string pwz)
        {
            return FakeDatabase.Appointments.Where(appointemnt => appointemnt.PWZ == pwz).ToArray();
        }

        public Appointment[] GetAppointmentsByPesel(string pesel)
        {
            return FakeDatabase.Appointments.Where(appointemnt => appointemnt.PESEL == pesel).ToArray();
        }

        public void AddAppointment(Appointment appointment)
        {
            FakeDatabase.Appointments.Add(appointment);
        }

        public void DeleteAppointment(int id)
        {
            Appointment appointmentToRemove = FakeDatabase.Appointments.Find(appointment => appointment.Id == id);
            FakeDatabase.Appointments.Remove(appointmentToRemove);
        }
    }
}