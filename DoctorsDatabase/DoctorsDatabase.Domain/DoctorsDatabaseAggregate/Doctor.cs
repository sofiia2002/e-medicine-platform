namespace DoctorsDatabase.Domain.DoctorsDatabaseAggregate
{
    using DoctorsDatabase.Domain.SeedWork;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Doctor
    {
        public string FirstName 
        {
            get { return firstName; }

            internal set
            {
                Debug.Assert(condition: !string.IsNullOrWhiteSpace(value));

                firstName = value;
            }
        }

        public string LastName 
        {
            get { return lastName; }

            internal set
            {
                Debug.Assert(condition: !string.IsNullOrWhiteSpace(value));

                lastName = value;
            }
        }

        public string PWZ 
        {
            get { return pwz; }

            internal set
            {
                Debug.Assert(condition: !string.IsNullOrWhiteSpace(value));

                pwz = value;
            }
        }

        public List<string> Specializations;

        private string firstName;
        private string lastName;
        private string pwz;

        public Doctor( string firstName, string lastName, string pwz, List<string> specializations)
        {
            Debug.Assert(condition: specializations.Count > 0);
            Specializations = specializations;
            PWZ = pwz;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
