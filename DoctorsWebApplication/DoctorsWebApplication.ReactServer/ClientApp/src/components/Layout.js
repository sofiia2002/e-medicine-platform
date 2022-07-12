import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import "../styles/Layout.css";

export class Layout extends Component {
  static displayName = Layout.name;

  render () {
    return (
        <div className="layout">
          <NavMenu />
          <Container className="container-body">
            {this.props.children}
          </Container>
        </div>
    );
  }
}
