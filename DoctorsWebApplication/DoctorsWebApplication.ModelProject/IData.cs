namespace DoctorsWebApplication.ModelProject
{
  using System;
  using System.Collections.Generic;

  using System.ComponentModel;

    public interface IData : INotifyPropertyChanged
  {
    //string SearchText { get; set; }
    //List<NodeData> NodeList { get; }
    //NodeData SelectedNode { get; set; }

        List<AppointmentData> Appointments { get;}

        List<AvailabilityData> Availabilities { get; }

        DateTime AvailabilityDateTime { get; set; }

        DoctorData Doctor { get; }

        List<PatientData> Patients { get; }

        PatientData SelectedPatient { get; set; }

        PatientData PatientDetails { get; }

        AppointmentData SelectedAppointment { get; set; }

        AppointmentData AppointmentDetails { get; }

        AvailabilityData SelectedAvailability { get; set; }

        AvailabilityData AvailabilityToAdd { get; set; }
  }
}
