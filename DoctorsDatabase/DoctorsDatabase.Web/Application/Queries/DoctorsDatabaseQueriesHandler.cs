namespace DoctorsDatabase.Web.Application.Queries
{
    using DoctorsDatabase.Web.Application.Mapper;
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using DoctorsDatabase.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DoctorsDatabase.Infrastructure;

    public class DoctorsDatabaseQueriesHandler : IDoctorsDatabaseQueriesHandler
    {
        private readonly IDatabaseService databaseService;

        public DoctorsDatabaseQueriesHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return databaseService.GetDoctors().Select(r => r.Map());
        }

        public DoctorDto GetDoctorByPWZ(string pwz)
        {
            return databaseService.GetDoctorByPWZ(pwz).Map();
        }

        public IEnumerable<DoctorDto> GetDoctorsBySpec(string specialization)
        {
            return databaseService.GetDoctorsBySpec(specialization).Select(r => r.Map());
        }
    }
}
