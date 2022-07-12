import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Appointments } from './components/Appointments';
import { Availabilities } from './components/Availabilities';
import { Patients } from './components/Patients';
import { MuiPickersUtilsProvider } from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
             <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/patients' component={Patients} />
                <Route path='/appointments' component={Appointments} />
                <Route path='/availabilities' component={Availabilities} />
             </Layout>
          </MuiPickersUtilsProvider>
    );
  }
}
