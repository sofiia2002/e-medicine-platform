namespace DoctorsWebApplication.ModelProject
{
    using System.Collections.Generic;
    public class DoctorData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<int> Specializations { get; set; }

        public string Pwz { get; set; }

        public DoctorData(string name, string lastname, string pwz, IEnumerable<int> specializations)
        {
            Name = name;
            LastName = lastname;
            Pwz = pwz;
            Specializations = specializations;
        }
    }
}
