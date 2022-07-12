namespace PatientsApplicationMicroservice.Web.Application.Dtos
{
    using System.Collections.Generic;
    using System;

    public class DoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PWZ { get; set; }

        public List<string> Specializations { get; set; }


        public DoctorDto(string firstName, string lastName, string pwz, List<string> specializations)
        {
            FirstName = firstName;
            LastName = lastName;
            PWZ = pwz;
            Specializations = specializations;
        }
    }
}
