namespace DoctorsDatabase.Web.Application.Mapper
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using DoctorsDatabase.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public static class Mapper
    {
        public static DoctorDto Map(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            return new DoctorDto
            {
                FirstName = doctor.FirstName,
                Specializations = doctor.Specializations,
                LastName = doctor.LastName,
                PWZ = doctor.PWZ
            };
        }

        public static AvailabilityDto Map(this Availability availability)
        {
            if (availability == null)
                return null;

            return new AvailabilityDto
            {
                Id=availability.Id,
                Start_Date = availability.Start_Date,
                End_Date = availability.End_Date,
                PWZ = availability.PWZ
            };
        }
    }
}
