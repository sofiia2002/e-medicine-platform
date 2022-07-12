namespace DoctorsDatabase.Web.Application.Commands
{
    using DoctorsDatabase.Domain.DoctorsDatabaseAggregate;
    using DoctorsDatabase.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class AvailabilityDatabaseCommandsHandler : ICommandHandler<AddAvailabilityCommand>
    {
        private readonly IDatabaseService databaseService;

        public AvailabilityDatabaseCommandsHandler(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public void Handle(AddAvailabilityCommand command)
        {
            var list = databaseService.GetAvailabilities().ToList();
            list.Sort(AvailabilitySort);

            var lastElem = list.Last();

            var maxId = 0;

            if (lastElem != null)
            {
                maxId = lastElem.Id;
            }

            databaseService.AddAvailability(new Availability(maxId+1,command.Start_Date, command.End_Date, command.PWZ));
        }


        public int AvailabilitySort(Availability a, Availability b)
        {
            return a.Id.CompareTo(b.Id);
        }
    }
}
