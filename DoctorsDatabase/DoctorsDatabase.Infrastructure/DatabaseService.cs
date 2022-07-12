namespace DoctorsDatabase.Infrastructure
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    public class DatabaseService : IDatabaseService
    {
        private static XmlDocument databaseXmlDocument;

        private static readonly List<Availability> availabilities;

        private static readonly List<Doctor> doctors;

        private static readonly object databaseLock = new object();

        private const string databaseXsdFilename = "database.xsd";
        private const string databaseXmlFilename = "database.xml";

        static DatabaseService()
        {
            lock (DatabaseService.databaseLock)
            {
                DatabaseServiceReader databaseReader = new DatabaseServiceReader();

                DatabaseService.databaseXmlDocument = databaseReader.ReadXmlDocument(databaseXsdFilename, databaseXmlFilename);

                DatabaseService.availabilities = DatabaseServiceReader.ReadAvailabilities(databaseXmlDocument).ToList();

                DatabaseService.doctors = DatabaseServiceReader.ReadDoctors(databaseXmlDocument).ToList();
            }
        }


        public DatabaseService()
        {
        }


        public IEnumerable<Doctor> GetDoctors()
        {
            lock (DatabaseService.databaseLock)
            {
                return DatabaseService.doctors;
            }
        }

        public Doctor GetDoctorByPWZ(string pwz)
        {
            lock (DatabaseService.databaseLock)
            {

                foreach (var doc in DatabaseService.doctors)
                {
                    if (doc.PWZ.Equals(pwz))
                    {
                        return doc;
                    }
                }
                return null;
            }
        }

        public IEnumerable<Doctor> GetDoctorsBySpec(string specialization)
        {
            lock (DatabaseService.databaseLock)
            {
                return DatabaseService.doctors.Where(doc => doc.Specializations.Contains(specialization));
            }
        }

        public IEnumerable<Availability> GetAvailabilities()
        {
            lock (DatabaseService.databaseLock)
            {
                return DatabaseService.availabilities;
            }
        }

        public IEnumerable<Availability> GetAvailabilitiesByPWZ(string pwz)
        {
            lock (DatabaseService.databaseLock)
            {
                return DatabaseService.availabilities.Where(availability => availability.PWZ.Equals(pwz));
            }
        }

        public void AddAvailability(Availability availability)
        {
            lock (DatabaseService.databaseLock)
            {
                var doctorAvailability = DatabaseService.availabilities.FindAll(ava=>ava.PWZ==availability.PWZ);
                if (availability.Start_Date >= availability.End_Date)
                    return;
                if (doctorAvailability.Count == 0)
                {
                    DatabaseService.availabilities.Add(availability);
                    return;
                }
                // Case 1 in
                var containingAvailability = doctorAvailability.Find(ava => (ava.Start_Date <= availability.Start_Date) && (ava.End_Date >= availability.End_Date));
                if (containingAvailability != null)
                {
                    return;
                }

                var toDeleteList = doctorAvailability.FindAll(ava =>
                {
                    if ((ava.Start_Date >= availability.Start_Date) && (ava.End_Date <= availability.End_Date))
                    {
                        return true;
                    }
                    return false;
                });

                foreach (var toDelete in toDeleteList)
                {
                    DatabaseService.availabilities.Remove(toDelete);
                }

                //Case 2 expanding
                var list = doctorAvailability.FindAll(ava =>
                {
                    if ((ava.Start_Date < availability.Start_Date) && (ava.End_Date <= availability.End_Date) && (ava.End_Date >= availability.Start_Date))
                    {
                        return true;
                    }

                    if ((ava.Start_Date >= availability.Start_Date) && (ava.End_Date > availability.End_Date) && (ava.Start_Date <= availability.End_Date))
                    {
                        return true;
                    }
                    return false;
                });

                //Case 3 no overlap
                if (list.Count == 0)
                {
                    DatabaseService.availabilities.Add(availability);
                }

                if (list.Count == 1)
                {
                    //Case 2.1 expanding from right
                    if (list[0].Start_Date < availability.Start_Date)
                    {
                        list[0].End_Date = availability.End_Date;
                    }
                    //Case 2.2 expanding form left
                    if (list[0].End_Date > availability.End_Date)
                    {
                        list[0].Start_Date = availability.Start_Date;
                    }
                }

                if (list.Count == 2)
                {
                    //Case 2.1 expanding from right
                    if (list[0].Start_Date < availability.Start_Date)
                    {
                        list[0].End_Date = list[1].End_Date;
                    }
                    //Case 2.2 expanding form left
                    if (list[0].End_Date > availability.End_Date)
                    {
                        list[0].Start_Date = list[1].Start_Date;
                    }
                    DatabaseService.availabilities.Remove(list[1]);
                }

                DatabaseServiceWriter.SaveAll(DatabaseService.availabilities, DatabaseService.doctors);
            }
        }

        public void RemoveAvailability(int id, string pwz)
        {
            lock (DatabaseService.databaseLock)
            {
                var toDelete = DatabaseService.availabilities.Find(x => x.Id == id);
                if (toDelete != null)
                {
                    if (toDelete.PWZ.Equals(pwz))
                    {
                        DatabaseService.availabilities.Remove(toDelete);
                        DatabaseServiceWriter.SaveAll(DatabaseService.availabilities, DatabaseService.doctors);
                    }
                    else
                    {
                        throw new Exception("Unauthorized");
                    }
                }
            }
        }

        public void RemoveAvailabilityByDate(DateTime startDate, string pwz)
        {
            lock (DatabaseService.databaseLock)
            {
                var oneHour = new TimeSpan(1, 0, 0);

                foreach (var availability in DatabaseService.availabilities)
                {
                    if ((availability.Start_Date <= startDate) && (availability.End_Date > startDate) && (availability.PWZ.Equals(pwz)))
                    {
                        if (startDate + oneHour == availability.End_Date)
                        {
                            availability.End_Date -= oneHour;
                            if (availability.Start_Date >= availability.End_Date)
                                DatabaseService.availabilities.Remove(availability);
                            break;
                        }
                        else if (availability.Start_Date == startDate)
                        {
                            availability.Start_Date += oneHour;
                            if (availability.Start_Date >= availability.End_Date)
                                DatabaseService.availabilities.Remove(availability);
                            break;
                        }
                        else
                        {
                            var deleteId = availability.Id;
                            var maxId = DatabaseService.availabilities.Max(r => r.Id);


                            var startDate1 = availability.Start_Date;
                            var endDate1 = startDate;

                            var startDate2 = startDate + oneHour;
                            var endDate2 = availability.End_Date;

                            var newAvailability1 = new Availability(maxId + 1, startDate1, endDate1, pwz);
                            var newAvailability2 = new Availability(maxId + 2, startDate2, endDate2, pwz);

                            var toDelete = DatabaseService.availabilities.Find(x => x.Id == deleteId);
                            DatabaseService.availabilities.Remove(toDelete);
                            if (!newAvailability1.Start_Date.Equals(newAvailability1.End_Date))
                            {
                                AddAvailability(newAvailability1);
                            }
                            if (!newAvailability2.Start_Date.Equals(newAvailability2.End_Date))
                            {
                                AddAvailability(newAvailability2);
                            }
                            break;
                        }
                    }
                }
                DatabaseServiceWriter.SaveAll(DatabaseService.availabilities, DatabaseService.doctors);
            }
        }

        public void RemoveAvailabilityBySpan(DateTime startDate, DateTime endDate, string pwz)
        {
            if (startDate >= endDate)
                return;

            var doctorAvailability = DatabaseService.availabilities.Find(ava => (ava.PWZ == pwz)&&(ava.Start_Date<=startDate)&&(ava.End_Date>=endDate));

            if ((doctorAvailability.Start_Date == startDate) && (doctorAvailability.End_Date == endDate))
            {
                DatabaseService.availabilities.Remove(doctorAvailability);
            }
            else if (doctorAvailability.Start_Date == startDate)
            {
                doctorAvailability.Start_Date = endDate;
            }
            else if (doctorAvailability.End_Date == endDate)
            {
                doctorAvailability.End_Date = startDate;
            }
            else
            {

                var maxId = DatabaseService.availabilities.Max(r => r.Id);

                DatabaseService.availabilities.Add(new Availability(maxId+1, doctorAvailability.Start_Date, startDate, pwz));
                DatabaseService.availabilities.Add(new Availability(maxId + 2, endDate, doctorAvailability.End_Date, pwz));

                DatabaseService.availabilities.Remove(doctorAvailability);
            }
        }

    }
}
