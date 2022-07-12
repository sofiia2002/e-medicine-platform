namespace DoctorMicroservice.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RemoveAvailabilityBySpan
    {
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string PWZ { get; set; }
    }
}
