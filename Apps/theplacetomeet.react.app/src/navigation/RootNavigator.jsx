import React from "react";
import {Routes, Route} from "react-router-dom";
import Home from "../screens/Home";
import Login from "../screens/Login";
import Register from "../screens/Register";
import Reservation from "../screens/Reservation";
import MyReservations from "../screens/MyReservations";
import axios from "axios";

axios.defaults.baseURL = "https://localhost:7045";

const RootNavigator = () => {
  return (
    <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/reservation" element={<Reservation />} />
        <Route path="/myreservations" element={<MyReservations />} />
    </Routes>
  )
}

export default RootNavigator