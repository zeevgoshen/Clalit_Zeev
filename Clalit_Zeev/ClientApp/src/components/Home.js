import React, { Component } from 'react';
import ExchangeRates from "./ExchangeRates";
import { HOME_TITLE } from "../constants/messages.js"

export class Home extends Component {
    static displayName = Home.name;


    constructor(props) {
        super(props);
        this.state = { exchangerates: [], loading: true };
    }

    componentDidMount() {
        this.populateExchangeRateData();
    }

    async populateExchangeRateData() {
        const response = await fetch('exchangerates');
        const data = await response.json();
        this.setState({ exchangerates: data, loading: false });
    }


    static renderExchangeRatesTable(exchangerates) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>CurrentChange</th>
                        <th>CurrentExchangeRate</th>
                        <th>Key</th>
                        <th>LastUpdate</th>
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
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }
}
