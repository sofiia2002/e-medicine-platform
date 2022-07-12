using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsDatabase.Infrastructure
{
    public interface IDatabaseService
    {
        public IEnumerable<Doctor> GetDoctors();

        public Doctor GetDoctorByPWZ(string pwz);

        public IEnumerable<Doctor> GetDoctorsBySpec(string specialization);

        public void AddAvailability(Availability availability);

        public IEnumerable<Availability> GetAvailabilitiesByPWZ(string pwz);

        public IEnumerable<Availability> GetAvailabilities();

        public void RemoveAvailability(int Id, string pwz);

        public void RemoveAvailabilityByDate(DateTime startDate, string pwz);
        public void RemoveAvailabilityBySpan(DateTime startDate, DateTime endDate, string pwz);
    }
}
