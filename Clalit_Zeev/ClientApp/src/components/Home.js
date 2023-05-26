import React from 'react';
import ExchangeRates from "./ExchangeRates";
import { HOME_TITLE, GENERAL_NOTE } from "../constants/messages.js"

export default function Home() {

    return (
        <div>
            <h2 className="heading_margin_bottom">{HOME_TITLE}</h2>
            <ExchangeRates />
            <h3>{GENERAL_NOTE}</h3>
        </div>
    )
};
