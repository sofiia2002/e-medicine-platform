namespace DoctorMicroservice.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public string PESEL { get; set; }

        public string PWZ { get; set; }

        public DateTime StartDate { get; set; }
    }
}
