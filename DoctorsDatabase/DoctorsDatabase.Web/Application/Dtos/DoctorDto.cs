namespace DoctorsDatabase.Web.Application.Dtos
{
    using System.Collections.Generic;
    public class DoctorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PWZ { get; set; }

        public List<string> Specializations { get; set; }
    }
}
