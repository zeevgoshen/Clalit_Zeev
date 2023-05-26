import React from 'react';
import './Header.css';
import { HEADER_TEXT } from "../constants/messages.js"


export default function Header() {

    return (
        <div className="heading_margin_bottom"><h1><b>{HEADER_TEXT}</b></h1></div>
    );
}
