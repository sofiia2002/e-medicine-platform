namespace DoctorsDatabase.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AvailabilityDto
    {
        public int Id { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string PWZ { get; set; }
    }
}
