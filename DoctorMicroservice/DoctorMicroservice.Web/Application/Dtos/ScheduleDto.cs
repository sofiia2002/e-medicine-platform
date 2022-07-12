namespace DoctorMicroservice.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ScheduleDto
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Type { get; set; }
        public int AppointmentId { get; set; }

        public ScheduleDto(DateTime startDate, DateTime endDate)
        {
            Start_Date = startDate;
            End_Date = endDate;
            Type = "Availability";
        }
        public ScheduleDto(DateTime startDate, int appointmentId)
        {
            Start_Date = startDate;
            End_Date = startDate+ new TimeSpan(1,0,0);
            Type = "Appointment";
            AppointmentId = appointmentId;
        }
    }
}
