namespace DoctorsWebApplication.ModelProject
{
    using System;
    public class AvailabilityData
    {
        public int Id { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string Pwz { get; set; }
        

        public AvailabilityData(int id, DateTime startDate, DateTime endDate, string pwz)
        {
            Id = id;
            Start_Date = startDate;
            End_Date = endDate;
            Pwz = pwz;
        }
    }
}
