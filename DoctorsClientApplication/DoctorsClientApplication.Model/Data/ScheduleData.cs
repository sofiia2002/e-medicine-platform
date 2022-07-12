namespace DoctorsClientApplication.Model
{
    using System;
    public class ScheduleData
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Type { get; set; }
        public int AppointmentId { get; set; }


        public ScheduleData(DateTime start_date, DateTime end_date, string type, int appointmentId)
        {
            Start_Date = start_date;
            End_Date = end_date;
            Type = type;
            AppointmentId = appointmentId;
        }

    }
}
