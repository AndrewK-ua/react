import React, { Component, useState } from 'react';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import Login from './components/Login';
import useToken from './UseToken';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

import './custom.css'

export default function App(){
    const { token, setToken } = useToken();

        if (!token) {
            return <Login setToken={setToken} />
        }

    return (
        <div className="wrapper">
            <h1>Lab 1</h1>
            <BrowserRouter>
                <Switch>
                    <Route path="/home" />
                </Switch>
            </BrowserRouter>
        </div>
        );
}
