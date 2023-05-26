import React, {  useState, useEffect } from "react";
import ExchangeService from "../services/exchange_rates.service.js";
import { NO_RESULTS } from "../constants/messages.js"
import "./ExchangeRates.css";


export default function ExchangeRates() {

    const [exchangerates, setExchangeRates] = useState({ loading: true });

    useEffect(() => {
        ExchangeService().then(response =>
            setExchangeRates({ response, loading: false }));
    }, []);

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
                {exchangerates.response?.length === 0 ?
                    (<tr><td colSpan="5">{NO_RESULTS}</td></tr>) :
                    (exchangerates.response?.map(exchangerate =>
                        <tr key={exchangerate.key}>
                            <td>{exchangerate.currentChange}</td>
                            <td>{exchangerate.currentExchangeRate}</td>
                            <td>{exchangerate.key}</td>
                            <td>{exchangerate.lastUpdate}</td>
                            <td>{exchangerate.unit}</td>
                        </tr>
                    ))
                }
            </tbody>
        </table>
    );
}
