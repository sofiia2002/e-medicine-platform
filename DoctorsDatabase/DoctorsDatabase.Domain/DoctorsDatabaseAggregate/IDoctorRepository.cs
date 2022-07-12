namespace DoctorsDatabase.Domain.DoctorsDatabaseAggregate
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
    }
}
