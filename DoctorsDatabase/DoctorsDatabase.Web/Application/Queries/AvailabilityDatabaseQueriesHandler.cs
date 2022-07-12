namespace DoctorsDatabase.Web.Application.Queries
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using DoctorsDatabase.Infrastructure;
    using DoctorsDatabase.Web.Application.Dtos;
    using DoctorsDatabase.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AvailabilityDatabaseQueriesHandler : IAvailabilityDatabaseQueriesHandler
    {
        private readonly IDatabaseService databaseService;

        public AvailabilityDatabaseQueriesHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public IEnumerable<AvailabilityDto> GetAll()
        {
            return databaseService.GetAvailabilities().Select(r => r.Map());
        }

        public IEnumerable<AvailabilityDto> GetAvailabilitiesByPWZ(string pwz)
        {
            return databaseService.GetAvailabilitiesByPWZ(pwz).Select(r => r.Map());
        }

        public void RemoveAvailability (int id, string pwz)
        {
            databaseService.RemoveAvailability(id,  pwz);
        }

        public void RemoveAvailabilityByDate(DateTime startDate,string pwz)
        {
            databaseService.RemoveAvailabilityByDate(startDate, pwz);
        }

        public void RemoveAvailabilityBySpan(DateTime startDate, DateTime endDate, string pwz)
        {
            databaseService.RemoveAvailabilityBySpan(startDate, endDate, pwz);
        }


    }
}
