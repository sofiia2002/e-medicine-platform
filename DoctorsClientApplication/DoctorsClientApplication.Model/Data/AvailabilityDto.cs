namespace DoctorsClientApplication.Model
{
    using System;
    public class AvailabilityDto
    {

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string Pwz { get; set; }

        public AvailabilityDto(DateTime startDate, DateTime endDate, string pwz)
        {
            Start_Date = startDate;
            End_Date = endDate;
            Pwz = pwz;
           
        }
    }
}
