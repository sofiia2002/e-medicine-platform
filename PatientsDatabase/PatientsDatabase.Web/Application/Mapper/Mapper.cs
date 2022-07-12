namespace PatientsDatabase.Web.Application.Mapper
{
    using PatientsDatabase.Domain.PatientsDatabaseAggregate;
    using PatientsDatabase.Web.Application.Dtos;

    public static class Mapper
    {
        public static PatientDto MapToDto(this Patient patient)
        {
            if (patient == null)
                return null;

            return new PatientDto
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                PESEL = patient.PESEL
            };
        }

        public static AppointmentDto MapToDto(this Appointment appointment)
        {
            if (appointment == null)
                return null;

            return new AppointmentDto
            {
                AppointmentId = appointment.Id,
                StartDate = appointment.StartDate,
                PWZ = appointment.PWZ,
                PESEL = appointment.PESEL
            };
        }

        public static Appointment MapFromDto(this AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
                return null;

            return new Appointment(appointmentDto.AppointmentId, appointmentDto.PESEL, appointmentDto.PWZ, appointmentDto.StartDate);
        }

        public static Patient MapFromDto(this PatientDto patientDto)
        {
            if (patientDto == null)
                return null;

            return new Patient(patientDto.FirstName, patientDto.LastName, patientDto.PESEL);

        }
    }
}
