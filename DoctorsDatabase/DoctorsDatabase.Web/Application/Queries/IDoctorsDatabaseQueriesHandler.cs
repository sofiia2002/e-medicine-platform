namespace DoctorsDatabase.Web.Application.Queries
{
    using DoctorsDatabase.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorsDatabaseQueriesHandler
    {
        public IEnumerable<DoctorDto> GetAll();
        public DoctorDto GetDoctorByPWZ(string pwz);
        public IEnumerable<DoctorDto> GetDoctorsBySpec(string specialization);
    }
}
