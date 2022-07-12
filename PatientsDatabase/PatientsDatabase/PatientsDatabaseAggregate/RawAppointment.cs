namespace PatientsDatabase.Domain.PatientsDatabaseAggregate
{
    using System;
    public class RawAppointment
    {
        public string PESEL { get; private set; }
        public string PWZ { get; private set; }
        public DateTime StartDate { get; private set; }

        public RawAppointment(string pesel, string pwz, DateTime startdate)
        {
            PESEL = pesel;
            PWZ = pwz;
            StartDate = startdate;
        }
    }
}
