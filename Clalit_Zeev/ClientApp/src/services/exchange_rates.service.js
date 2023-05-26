import axios from "axios";

export default async function callExchangeRatesAPI() {

    const options = {
        headers: {
            "content-type": "application/json",
        },
    };

    return await axios.get("exchangerates", options)
        .then((response) => response.data)
        .catch((err) => console.log(err));
}