namespace DoctorsDatabase.Web.Controllers
{
    using DoctorsDatabase.Web.Application.Commands;
    using DoctorsDatabase.Web.Application.Dtos;
    using DoctorsDatabase.Web.Application.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class DoctorsDatabaseController : ControllerBase
    {
        private readonly ILogger<DoctorsDatabaseController> logger;
        private readonly IDoctorsDatabaseQueriesHandler doctorQueriesHandler;
        private readonly IAvailabilityDatabaseQueriesHandler availabilityQueriesHandler;
        private readonly ICommandHandler<AddAvailabilityCommand> addAvailabilityCommandHandler;


        public DoctorsDatabaseController(ILogger<DoctorsDatabaseController> logger, IDoctorsDatabaseQueriesHandler doctorQueriesHandler, IAvailabilityDatabaseQueriesHandler availabilityQueriesHandler, ICommandHandler<AddAvailabilityCommand> addAvailabilityCommandHandler)
        {
            this.logger = logger;
            this.doctorQueriesHandler = doctorQueriesHandler;
            this.availabilityQueriesHandler = availabilityQueriesHandler;
            this.addAvailabilityCommandHandler = addAvailabilityCommandHandler;
        }

        [HttpGet("get-doctors")]
        public IEnumerable<DoctorDto> GetAllDoctors()
        {
            return doctorQueriesHandler.GetAll();
        }

        [HttpGet("get-doctor-by-pwz")]
        public DoctorDto GetDoctorByPwz([FromQuery] string pwz)
        {
            return doctorQueriesHandler.GetDoctorByPWZ(pwz);
        }

        [HttpGet("get-doctors-by-specialization")]
        public IEnumerable<DoctorDto> GetDoctorBySpec([FromQuery] string specialization)
        {
            return doctorQueriesHandler.GetDoctorsBySpec(specialization);
        }

        [HttpGet("get-availabilities")]
        public IEnumerable<AvailabilityDto> GetAllAvailabilities()
        {
            return availabilityQueriesHandler.GetAll();
        }

        [HttpGet("get-availabilities-by-pwz")]
        public IEnumerable<AvailabilityDto> GetAvailabilitiesByPwz([FromQuery] string pwz)
        {
            return availabilityQueriesHandler.GetAvailabilitiesByPWZ(pwz);
        }

        [HttpPost("add-availability")]
        public void AddAvailability([FromBody] AddAvailabilityCommand availabilityCommand)
        {
            addAvailabilityCommandHandler.Handle(availabilityCommand);
        }

        [HttpDelete("remove-availability")]
        public void RemoveAvailability([FromBody] RemoveAvailabilityCommand removeAvailability)
        {
            availabilityQueriesHandler.RemoveAvailability(removeAvailability.Id, removeAvailability.PWZ);
        }

        [HttpDelete("remove-availability-span")]
        public void RemoveAvailabilityBySpan([FromBody] RemoveAvailabilityBySpan remover)
        {
            availabilityQueriesHandler.RemoveAvailabilityBySpan(remover.Start_Date,remover.End_Date,remover.PWZ);
        }

        [HttpDelete("reserve-appointment-date")]
        public void RemoveAvailabilityByDate([FromBody] AvailabilityCommand removeAvailabilityByDate)
        {
            availabilityQueriesHandler.RemoveAvailabilityByDate(removeAvailabilityByDate.startDate, removeAvailabilityByDate.PWZ);
        }

        [HttpDelete("cancel-appointment-date")]
        public void CancelReservation([FromBody] AvailabilityCommand releaseAvailabilityByDate)
        {
            var availabilityCommand = new AddAvailabilityCommand();
            availabilityCommand.PWZ = releaseAvailabilityByDate.PWZ;
            availabilityCommand.Start_Date = releaseAvailabilityByDate.startDate;
            availabilityCommand.End_Date = releaseAvailabilityByDate.startDate+ new TimeSpan(1,0,0);
            addAvailabilityCommandHandler.Handle(availabilityCommand);
        }
    }
}
