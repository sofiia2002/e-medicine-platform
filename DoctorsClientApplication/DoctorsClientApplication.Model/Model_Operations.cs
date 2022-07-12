namespace DoctorsClientApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public partial class Model : IOperations
    {
    #if DEBUG
        private FakeDoctorClient doctorClient = new FakeDoctorClient();
    #else
        private DoctorClient doctorClient = new DoctorClient();
    #endif

        public async Task LoadAppointments()
        {
            await Task.Run(() => this.LoadAppointmentsTask());
        }

        public async Task LoadAppointmentDetails()
        {
            await Task.Run(() => this.LoadAppointmentDetailsTask());
        }

        public async Task LoadAvailability()
        {
            await Task.Run(() => this.LoadAvailabilityTask());
        }

        public async Task LoadPatients()
        {
            await Task.Run(() => this.LoadPatientsTask());
        }

        public async Task AddDoctorAvailability()
        {
            await Task.Run(() => this.AddDoctorAvailabilityTask());
        }

        public async Task DeleteDoctorAvailability()
        {
            await Task.Run(() => this.DeleteDoctorAvailabilityTask());
        }

        private async Task LoadAppointmentsTask()
        {
            try
            {
                this.Appointments = await this.doctorClient.GetAppointments(Doctor.Pwz);
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }


        private async Task LoadAvailabilityTask()
        {
            try
            {
                List<ScheduleData> availabilitiesAndAppointments = await this.doctorClient.GetSchedule(Doctor.Pwz);
                this.Availabilities = new List<AvailabilityData>();
                List<ScheduleData> scheduleAvailabilityData = availabilitiesAndAppointments.Where(x => x.Type == "Availability").ToList();
                scheduleAvailabilityData.Sort((x,y)=>DateTime.Compare(x.Start_Date, y.Start_Date));
                foreach (ScheduleData scheduleAvailability in scheduleAvailabilityData)
                {
                    this.Availabilities.Add(new AvailabilityData(scheduleAvailability.AppointmentId, scheduleAvailability.Start_Date, scheduleAvailability.End_Date, Doctor.Pwz));
                }

            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

        private async Task LoadAppointmentDetailsTask()
        {
            try
            {
                if (this.selectedAppointment != null)
                {
                    this.AppointmentDetails = await this.doctorClient.GetAppointmentDetails(this.selectedAppointment.AppointmentId, Doctor.Pwz);
                    if (this.AppointmentDetails != null)
                    {
                        this.PatientDetails = await this.doctorClient.GetPatientDetails(this.AppointmentDetails.PESEL, Doctor.Pwz);
                    }
                }
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

        private async Task LoadPatientsTask()
        {
            try
            {
                this.Patients = await this.doctorClient.GetMyPatients(Doctor.Pwz);
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

        private async Task DeleteDoctorAvailabilityTask()
        {
            try
            {
                if (this.selectedAvailability != null && this.availabilities.Contains(this.selectedAvailability))
                {
                    await this.doctorClient.DeleteAvailability(this.selectedAvailability);
                }

            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }

        private async Task AddDoctorAvailabilityTask()
        {
            try
            {
                DateTime endDate = new DateTime(this.AvailabilityDateTime.Year, this.AvailabilityDateTime.Month, this.AvailabilityDateTime.Day, this.AvailabilityDateTime.Hour + 1, this.AvailabilityDateTime.Minute, this.AvailabilityDateTime.Second);
                AvailabilityDto availabilityToAdd = new AvailabilityDto(this.AvailabilityDateTime, endDate, Doctor.Pwz);
                List<AvailabilityDto> oldAvailabilities = new List<AvailabilityDto>();
                foreach (AvailabilityData availabilityData in this.availabilities)
                {
                    oldAvailabilities.Add(new AvailabilityDto(availabilityData.Start_Date, availabilityData.End_Date, availabilityData.Pwz));
                }
                if (this.AvailabilityDateTime != null && !oldAvailabilities.Contains(availabilityToAdd))
                {
                    await this.doctorClient.CreateAvailability(availabilityToAdd);
                }
            }
            catch (Exception e)
            {
                string a = e.Message;
            }
        }


    }
}
