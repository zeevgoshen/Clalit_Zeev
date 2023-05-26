import React from 'react';
import Header from './Header';
import Home from './Home';
import { Container } from 'reactstrap'


export default function Layout() {

    return (
        <Container>
            <Header />
            <Home/>
        </Container>
    );
}
