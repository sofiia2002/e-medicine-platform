namespace PatientsApplicationMicroservice.Web.Application.Dtos
{
    using System;

    public class AvailabilityDto
    {
        public int Id { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string PWZ { get; set; }
    }
}
