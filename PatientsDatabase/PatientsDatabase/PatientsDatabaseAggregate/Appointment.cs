namespace PatientsDatabase.Domain.PatientsDatabaseAggregate
{
    using System;
    using PatientsDatabase.Domain.SeedWork;

    public class Appointment : Entity
    {
        public string PESEL { get; private set; }
        public string PWZ { get; private set; }
        public DateTime StartDate { get; private set; }

        public Appointment(int id, string pesel, string pwz, DateTime startdate) : base(id)
        {
            PESEL = pesel;
            PWZ = pwz;
            StartDate = startdate;
        }
    }
}
