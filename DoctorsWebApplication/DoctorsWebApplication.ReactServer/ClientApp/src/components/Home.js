import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            doctorData: null,
            loading: true
        };
    }

    componentDidMount() {
        this.doctorInfo();
    }

    async doctorInfo() {
        const response = await fetch('doctor-info');
        const data = await response.json();
        this.setState({ doctorData: data, loading: false });
    }

    render () {
        return (
            <div>
                <h1>Hello{this.state.doctorData ? ", " + this.state.doctorData.name + " " + this.state.doctorData.lastName : "" }!</h1>
                <p>Welcome to your single-page web application, where you can:</p>
                <ul>
                    <li>Manage your availabilities</li>
                    <li>Take a look at your appointments</li>
                    <li>Take a look at your patients</li>
            </ul>
            <p>Choose the option you're interested in on the navigation menu!</p>
        </div>
        );
    }
}
