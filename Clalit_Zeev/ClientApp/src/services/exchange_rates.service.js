import axios from "axios";

export default function callExchangeRatesAPI() {

    const options = {
        headers: {
            "content-type": "application/json",
        },
    };

    return axios.get("exchangerates", options)
        .then((response) => response.data)
        .catch((err) => console.log(err));
}