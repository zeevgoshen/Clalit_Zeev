import { useState, useEffect } from "react";
import axios from "axios";
import { APIURL } from "../constants/messages.js";

export async function callExchangeRatesAPI() {

    const options = {
        headers: {
            "content-type": "application/json",
        },
    };

    alert();

    await axios.get("exchangerates", options)
        .then((response) => response.data)
        .catch((err) => console.log(err));

}