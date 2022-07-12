import React, { Component } from 'react';
import App from '../App';
import '../styles/Appointments.css';

export class Appointments extends Component {
  static displayName = Appointments.name;

  constructor(props) {
      super(props);
      this.state = { appointments: [], loading: true, selectedAppointment: null, patientDetails: null, hidePopup: true  };
  }

    componentDidMount() {
        this.appointmentsData();
    }

    componentDidUpdate(prevProp, prevState) {
        if (this.state.selectedAppointment !== prevState.selectedAppointment && this.state.selectedAppointment) {
            this.patientDetailsData();
        }
    }

    renderPatientDetails() {
        const closePopup = () => {
            this.setState({ hidePopup: true });
            setTimeout(() => this.setState({ patientDetails: null, selectedAppointment: null }), 200)
        }

        return (
            <>
                <div className={!this.state.hidePopup ? "show patient-pop-up" : "hide patient-pop-up"}>
                    <div onClick={() => closePopup()}>x</div>
                    <div className="pop-up-text">
                        <h4>Appointment details:</h4>
                        {!this.state.patientDetails ? <div>Loading...</div> :
                            <>
                                <h6> Patient:</h6>
                                <p> {this.state.patientDetails ? this.state.patientDetails.firstName : ""} {this.state.patientDetails ? this.state.patientDetails.lastName : ""}</p>
                                <h6> PESEL:</h6>
                                <p> {this.state.patientDetails ? this.state.patientDetails.pesel : ""}</p>
                                <h6> Date: </h6>
                                <p>{this.state.selectedAppointment ? this.state.selectedAppointment.startDate.substr(0, 10) : ""} </p>
                                <h6> Time: </h6>
                                <p>{this.state.selectedAppointment ? this.state.selectedAppointment.startDate.substr(11, 5) + "-" + (parseInt(this.state.selectedAppointment.startDate.substr(11, 2)) + 1) + this.state.selectedAppointment.startDate.substr(13, 3) : ""} </p>
                            </>
                        }
                    </div>
                </div>
            </>
        );
    }


    renderAppointmentsTable(appointments) {
        const assignAppointment = (appointment) => {
            this.setState({ selectedAppointment: appointment, hidePopup: false });
        }

    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Year</th>
                    <th>Month</th>
                    <th>Day</th>
                    <th>Start</th>
                    <th>End</th>
                    <th>Info</th>
                </tr>
            </thead>
            <tbody>
                {appointments.map(appointment =>
                    <tr key={appointment.appointmentId}>
                        <td>{appointment.startDate.substr(0, 4)}</td>
                        <td>{appointment.startDate.substr(5, 2)}</td>
                        <td>{appointment.startDate.substr(8, 2)}</td>
                        <td>{appointment.startDate.substr(11, 5)}</td>
                        <td>{parseInt(appointment.startDate.substr(11, 2)) + 1}{appointment.startDate.substr(13, 3)}</td>
                        <td className="patient-info" onClick={()=>assignAppointment(appointment)}>
                            <i class="fa fa-info-circle" aria-hidden="true"></i>
                        </td>
                    </tr>
                )}
            </tbody>
      </table>
    );
    }


  render() {
    return (
      <div>
        <h1 id="tabelLabel" >Your Appointments</h1>
            {this.state.loading
                ? <p><em>Loading...</em></p>
                : this.renderAppointmentsTable(this.state.appointments)}
            {this.renderPatientDetails(this.state.selectedPatient)}
        </div>

    );
  }

    async appointmentsData() {
        const response = await fetch('my-appointments');
        const data = await response.json();
        this.setState({ appointments: data, loading: false });
    }

    async patientDetailsData() {
        const response = await fetch("appointment-details-patient",{
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(this.state.selectedAppointment)
        });
        const data = await response.json();
        this.setState({ patientDetails: data });
    } 
}
