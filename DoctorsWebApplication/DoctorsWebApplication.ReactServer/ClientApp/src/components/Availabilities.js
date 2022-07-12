import React, { Component } from 'react';
import { KeyboardDatePicker, KeyboardTimePicker } from "@material-ui/pickers";
import '../styles/Availability.css';

export class Availabilities extends Component {
    static displayName = Availabilities.name;

    constructor(props) {
        super(props);
        this.state = {
            availabilityData: [],
            loading: true,
            selectedAva: null,
            maxTime: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDay(), 19, 0, 0),
            minTime: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDay(), 8, 0, 0),
            selectedTime: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDay(), new Date().getHours() + 1, 0, 0),
            selectedDate: new Date(),
            newAva: { id: 0, start_time: null, end_time: null, pwz: "1234567" },
            hidePopup: true
        };
    }


    componentDidMount() {
        console.log(new Date().getFullYear());
        this.availabilitiesData();
    }

    renderAvailabilitiesTable(availabilityData) {

        return (
            <>
                <table className='table table-striped' >
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Start</th>
                            <th>End</th>
                            <th>Remove</th>
                        </tr>
                    </thead>
                    <tbody>
                        {availabilityData.map((singleAva, index) =>
                            <tr key={index} onClick={() => this.setState({ selectedAva: singleAva })} >
                                <td>{singleAva.start_Date ? singleAva.start_Date.substr(0, 10) : ""} </td>
                                <td>{singleAva.start_Date ? singleAva.start_Date.substr(11, 5) : ""} </td>
                                <td>{singleAva.start_Date ? (parseInt(singleAva.start_Date.substr(11, 5))+1)+":00" : ""} </td>
                                <td onClick={() => this.deleteAvailability(singleAva)}><i className="fas fa-trash"></i></td>
                            </tr>
                        )}
                    </tbody>
                </table>

            </>
        )


    } 

    renderPopup() {
        const closePopup = () => {
            this.setState({ hidePopup: true });
            setTimeout(() => this.setState({
                selectedTime: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDay(), new Date().getHours() + 1, 0, 0),
                selectedDate: new Date()
            }), 200)
        }

        return (
            <>
                <div className={!this.state.hidePopup ? "show ava-pop-up" : "hide ava-pop-up"}>
                    <div onClick={() => closePopup()}>x</div>
                    <div className="ava-pop-up-text">
                        <h4>Enter details:</h4>
                        <div className="ava-pop-up-body">
                            <KeyboardDatePicker
                                autoOk
                                variant="inline"
                                inputVariant="outlined"
                                label="Select date"
                                format="dd.MM.yyyy"
                                minDate={new Date()}
                                value={this.state.selectedDate}
                                InputAdornmentProps={{ position: "start" }}
                                onChange={date => this.setState({ selectedDate: date })}
                            />
                            <KeyboardTimePicker
                                ampm={false}
                                inputVariant="outlined"
                                label="Select start time"
                                value={this.state.selectedTime}
                                minutesStep={60}
                                onChange={time => this.setState({ selectedTime: time })}
                            />
                            <button className={this.state.hidePopup ? "addAvaBtn hide-button" : "addAvaBtn"} onClick={() =>
                                {
                                if (!this.state.hidePopup)
                                    this.addAvailability();
                                closePopup()
                                }
                            } type="button">Add Availability</button>
                        </div>
                    </div>
                </div>
            </>
        );
    }

    render() {
        return (
            <div>
                <div className="MiniCont">
                    <h1 id="tabelLabel" >Your Availabilities</h1>
                    <button className="addApoBtn" onClick={() => this.setState({ hidePopup: false })} type="button">Add Availability</button>
                </div>
                {this.renderAvailabilitiesTable(this.state.availabilityData)}
                {this.renderPopup()}
            </div>
        );
    }

    async availabilitiesData() {
        const response = await fetch('my-availabilities');
        const avaData = await response.json();
        this.setState({ availabilityData: avaData, loading: false });
    }

    async addAvailability() {
        const ava = {
            id: this.state.newAva.id,
            start_Date: (new Date(this.state.selectedDate.getFullYear(), this.state.selectedDate.getMonth(), this.state.selectedDate.getDate(), this.state.selectedTime.getHours() + 2, 0, 0)).toISOString().split('.')[0],
            end_Date: (new Date(this.state.selectedDate.getFullYear(), this.state.selectedDate.getMonth(), this.state.selectedDate.getDate(), this.state.selectedTime.getHours() + 3, 0, 0)).toISOString().split('.')[0],
            pwz: this.state.newAva.pwz
        };
        const response = await fetch("add-availabiity", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(ava)
        });
        const avaData = await response.json();
        this.setState({ availabilityData: avaData, loading: false })
    }

    async deleteAvailability(singleAva) {
        const response = await fetch("delete-availability", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(singleAva)
        });
        const data = await response.json();
        this.setState({ availabilityData: data });
    }
}
