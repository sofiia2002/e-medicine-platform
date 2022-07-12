namespace DoctorsDatabase.Web.Application.Queries
{
    using DoctorsDatabase.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IAvailabilityDatabaseQueriesHandler
    {
        public IEnumerable<AvailabilityDto> GetAll();
        public IEnumerable<AvailabilityDto> GetAvailabilitiesByPWZ(string pwz);
        public void RemoveAvailability(int Id, string pwz);
        public void RemoveAvailabilityByDate(DateTime startDate, string pwz);
        public void RemoveAvailabilityBySpan(DateTime startDate, DateTime endDate, string pwz);
    }
}
