namespace PatientsDatabase.Domain.PatientsDatabaseAggregate
{
    public class Patient 
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PESEL { get; private set; }

        public Patient(string firstName, string lastName, string Pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            PESEL = Pesel;
        }
    }
}
