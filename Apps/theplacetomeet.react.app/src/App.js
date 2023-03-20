//import logo from './logo.svg';
import React, { Component, useEffect, useState } from "react";
//import ReactDOM from "react-dom";
import './App.css';
//import ThePlaceToMeet from "./clients/base/ThePlaceToMeet.js";
import { ApiClient, CustomerApi } from "./generated/javascript/src/index";
import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7045/chathub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.on("ProcessChatMessage", (user, message) => {
    console.log("From " + user + ": " + message);
});

connection.onclose(async () => {
    await start();
});

function App() {
    // Start the connection.
    // start(); 
    
    const [customers, setCustomers] = useState();

    // Function to collect data
    const getCustomerData = async () => {
        /*
        const response = await fetch(
            "http://localhost:5204/Klant/"
        ).then((response) => response.json());
        setCustomers(response);
        */

        /*
        var client = new ThePlaceToMeet();
        client.Customers(
            {
                status200: responseObject => {
                    console.log(responseObject);
                    setCustomers(JSON.parse(responseObject));
                },
                status404: responseText => {
                    alert('Not found. Here is the response from the server: ' + responseText);
                },                
                else: (statusCode, responseText) => {
                    alert('Oops, we were not expecting a HTTP status code of ' + statusCode);
                    console.error('unhandled response to status code ' + statusCode + ': ' + responseText);
                },
                error: error => {
                    alert('An error occurred.  Please view the console for more information.');
                    console.error(error);
                }
            }
        );
        */

        var client = new ApiClient(/*"https://localhost:7045"*/"http://localhost:5204");
        client.defaultHeaders = {
            'Access-Control-Allow-Origin': 'http://localhost:3000' // 'https://localhost:3000'
           //'User-Agent': 'OpenAPI-Generator/1.0/Javascript'
        };
        console.log(client.defaultHeaders);

        var customerApi = new CustomerApi(client);
        var callback = function (error, data, response)
        {
            console.log("Error: " + error);
            console.log("Data: " + data);
            console.log("Response: " + JSON.stringify(response));
            if (error === null && data !== null) {
                console.log("Setting customers...");
                setCustomers(data);
            }
        }
        customerApi.customerCustomers(callback);
    };

    useEffect(() => {
        getCustomerData();
    }, []);

    return (
        <div className="app">
            {customers && 
                customers.map((customer) => (
                    <div className="item-container" key={customer.id}>
                        Id:{customer.id} <div className="title">Name:{customer.lastName}</div>
                    </div>
                ))}
        </div>
    );
}

export default App;
