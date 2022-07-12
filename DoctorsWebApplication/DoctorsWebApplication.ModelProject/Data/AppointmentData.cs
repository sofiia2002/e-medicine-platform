namespace DoctorsWebApplication.ModelProject
{
    using System;
    public class AppointmentData
    {
        public int AppointmentId { get; set; }

        public string PESEL { get; set; }

        public string PWZ { get; set; }

        public DateTime StartDate { get; set; }

        public AppointmentData(int id, string pesel, string pwz, DateTime startDate)
        {
            AppointmentId = id;
            PESEL = pesel;
            PWZ = pwz;
            StartDate = startDate;
        }

        public AppointmentData()
        {
        }
    }
}
