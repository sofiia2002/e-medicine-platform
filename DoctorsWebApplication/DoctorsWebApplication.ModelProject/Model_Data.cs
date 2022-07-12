namespace DoctorsWebApplication.ModelProject
{
    using System;
    using System.Collections.Generic;

  public partial class Model : IData
  { 
    public DoctorData Doctor
    {
        get { return new DoctorData("Andrzej", "Grabowski", "1234567", new List<int>() { 0, 1, 2 }); }
        private set
        {
        }

    }

    public DateTime AvailabilityDateTime
    {
        get { return this.availabilityDateTime; }
        set
        {
            this.availabilityDateTime = value;

            this.RaisePropertyChanged("AvailabilityDateTime");
        }
    }

    public List<AppointmentData> Appointments
    {
        get { return this.appointments; }
        private set
        {
            this.appointments = value;

            this.RaisePropertyChanged("Appointments");
        }
    }

    public List<PatientData> Patients
    {
        get { return this.patients; }
        private set
        {
            this.patients = value;

            this.RaisePropertyChanged("Patients");
        }
    }

    public PatientData SelectedPatient
    {
        get { return this.selectedPatient; }
        set
        {
            this.selectedPatient = value;

            this.RaisePropertyChanged("SelectedPatient");
        }
    }

    public List<AvailabilityData> Availabilities
    {
        get { return this.availabilities; }
        private set
        {
            this.availabilities = value;

            this.RaisePropertyChanged("Availabilities");
        }
    }


    public AppointmentData AppointmentDetails
    {
        get { return this.appointmentDetails; }
        private set
        {
            this.appointmentDetails = value;

            this.RaisePropertyChanged("AppointmentDetails");
        }
    }

    public PatientData PatientDetails
    {
        get { return this.patientDetails; }
        private set
        {
            this.patientDetails = value;

            this.RaisePropertyChanged("PatientDetails");
        }
    }

    public AppointmentData SelectedAppointment
    {
        get
        {
            return this.selectedAppointment;
        }
        set
        {
            this.selectedAppointment = value;

            this.RaisePropertyChanged("SelectedAppointment");
        }
    }

    public AvailabilityData SelectedAvailability
    {
        get
        {
            return this.selectedAvailability;
        }
        set
        {
            this.selectedAvailability = value;

            this.RaisePropertyChanged("SelectedAvailability");
        }
    }

    public AvailabilityData AvailabilityToAdd
    {
        get
        {
            return this.availabilityToAdd;
        }
        set
        {
            this.availabilityToAdd = value;

            this.RaisePropertyChanged("AvailabilityToAdd");
        }
    }

    private List<AppointmentData> appointments = new List<AppointmentData>();
    private List<PatientData> patients = new List<PatientData>();
    private AppointmentData appointmentDetails = new AppointmentData();
    private List<AvailabilityData> availabilities = new List<AvailabilityData>();
    private PatientData patientDetails = new PatientData();
    private AppointmentData selectedAppointment;
    private PatientData selectedPatient;
    private AvailabilityData selectedAvailability;
    private AvailabilityData availabilityToAdd;
    private DateTime availabilityDateTime;
}
}
