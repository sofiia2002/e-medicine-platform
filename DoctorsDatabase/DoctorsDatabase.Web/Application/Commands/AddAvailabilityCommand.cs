namespace DoctorsDatabase.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class AddAvailabilityCommand : ICommand
    {
        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string PWZ { get; set; }
    }
}
