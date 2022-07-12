import React, { Component } from 'react';
import '../custom.css'

export class Patients extends Component {
  static displayName = Patients.name;

    constructor(props) {
        super(props);
        this.state = { patients: [], loading: true };
    }

    componentDidMount() {
        this.patientsData();
    }

    renderPatientsTable(patients) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>PESEL</th>
                    </tr>
                </thead>
                <tbody>
                    {patients.map(patient =>
                        <tr key={patient.pesel}>
                            <td>{patient.firstName}</td>
                            <td>{patient.lastName}</td>
                            <td>{patient.pesel}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    
    render() {
        return (
            <div>
                <h1 id="tabelLabel">Your Patients</h1>
                {this.state.loading
                    ? <p><em>Loading...</em></p>
                    : this.renderPatientsTable(this.state.patients)}
            </div>
        );
    }

    async patientsData() {
        const response = await fetch('my-patients');
        const data = await response.json();
        this.setState({ patients: data, loading: false });
    }
}
