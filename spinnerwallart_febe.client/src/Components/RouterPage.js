import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Login from './Login';
import Registration from './Registration';
import DashBoard from './Users/DashBoard';
import Orders from './Users/Orders';
import Profile from './Users/Profile';
import Cart from './Users/Cart';
export default function RouterPage() {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Registration />} />
                <Route path='/' element={<DashBoard />} />
                <Route path='/' element={<Orders />} />
                <Route path='/' element={<Profile />} />
                <Route path='/' element={<Cart />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
                <Route path='/' element={<Login />} />
            </Routes>
        </Router>
    )
}