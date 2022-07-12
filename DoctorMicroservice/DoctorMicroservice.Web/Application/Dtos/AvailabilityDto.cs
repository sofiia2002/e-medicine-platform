namespace DoctorMicroservice.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AvailabilityDto
    {
        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string PWZ { get; set; }

        public AvailabilityDto(DateTime start_Date, DateTime end_Date, string pwz)
        {
            Start_Date = start_Date;
            End_Date = end_Date;
            PWZ = pwz;
        }
    }
}
