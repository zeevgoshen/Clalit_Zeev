import React, { useMemo, useState, useEffect } from "react";
import "./ExchangeRates.css";

import { callExchangeRatesAPI } from "../services/exchange_rates.service.js";

export default function ExchangeRates() {

     
    return (
        <div className="main_content">
            <label className="mainTitle">todo title</label>

            <label className="secondaryTitle">
                1. The search is not case sensitive.
            </label>

            <button className="" onClick={() => callExchangeRatesAPI()}>Get Negative Change Rates</button>

           
        </div>
    );
}
