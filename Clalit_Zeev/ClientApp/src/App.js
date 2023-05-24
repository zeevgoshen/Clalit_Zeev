import React, { Component } from 'react';
import { Layout } from './components/Layout';
import './custom.css';
import { HOME_TITLE } from "./constants/messages.js"
import { Home } from './components/Home';

export default class App extends Component {
    static displayName = HOME_TITLE;

  render() {
      return (
          <Layout>
              <Home />
            </Layout>
    );
  }
}
