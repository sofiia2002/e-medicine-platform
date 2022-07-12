namespace PatientsApplicationMicroservice.Web.Application.Dtos
{
    using System;

    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        
        public string PESEL { get; set; }
        
        public string PWZ { get; set; }

        public DateTime StartDate { get; set; }
        public AppointmentDto(int appointmentId, string pesel, string pwz, DateTime startDate)
        {
            AppointmentId = appointmentId;
            PESEL = pesel;
            PWZ = pwz;
            StartDate = startDate;
        }


    }

   
}
