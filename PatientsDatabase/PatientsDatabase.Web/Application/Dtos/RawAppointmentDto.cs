namespace PatientsDatabase.Web.Application.Dtos
{
    using System;
    public class RawAppointmentDto
    {
        public string PESEL { get; set; }
        public string PWZ { get; set; }
        public DateTime StartDate { get; set; }
    }
}
