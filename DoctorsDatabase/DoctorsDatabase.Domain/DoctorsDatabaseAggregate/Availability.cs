namespace DoctorsDatabase.Domain.DoctorsDatabaseAggregate
{
    using DoctorsDatabase.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Availability : Entity
    {
        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string PWZ
        {
            get { return pwz; }

            internal set
            {
                Debug.Assert(condition: !string.IsNullOrWhiteSpace(value));

                pwz = value;
            }
        }
        private string pwz;

        public Availability(int id, DateTime startDate, DateTime endDate, string pwz) : base(id)
        {
            Start_Date = startDate;
            End_Date = endDate;
            PWZ = pwz;
        }
    }
}
