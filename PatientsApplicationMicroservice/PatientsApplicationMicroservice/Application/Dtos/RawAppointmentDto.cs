namespace PatientsApplicationMicroservice.Web.Application.Dtos
{
    using System;

    public class RawAppointmentDto
    {
        public string Pesel { get; set; }
        public string PWZ { get; set; }
        public DateTime StartDate { get; set; }
    }
}
