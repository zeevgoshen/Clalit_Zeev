import React, { Component } from 'react';
import ExchangeRates from "./ExchangeRates";
import ExchangeService from "../services/exchange_rates.service.js";
import { HOME_TITLE } from "../constants/messages.js"

export class Home extends Component {
    static displayName = HOME_TITLE;


    constructor(props) {
        super(props);
        this.state = { exchangerates: [], loading: true };
    }

    componentDidMount() {
        this.populateExchangeRateData();
    }

    async populateExchangeRateData() {
        const response = await ExchangeService();
        this.setState({ exchangerates: response, loading: false });
    }


    static renderExchangeRatesTable(exchangerates) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Current Change</th>
                        <th>Current Exchange Rate</th>
                        <th>Key</th>
                        <th>Last Update</th>
                        <th>Unit</th>
                    </tr>
                </thead>
                <tbody>
                    {exchangerates.map(exchangerate =>
                        <tr key={exchangerate.key}>
                            <td>{exchangerate.currentChange}</td>
                            <td>{exchangerate.currentExchangeRate}</td>
                            <td>{exchangerate.key}</td>
                            <td>{exchangerate.lastUpdate}</td>
                            <td>{exchangerate.unit}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {

        <ExchangeRates />

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderExchangeRatesTable(this.state.exchangerates);

        return (
            <div>
                <h1 id="tabelLabel">Negative Exchange Rates</h1>
                {/*<p>This component demonstrates fetching data from the server.</p>*/}
                {contents}
            </div>
        );
    }
}
