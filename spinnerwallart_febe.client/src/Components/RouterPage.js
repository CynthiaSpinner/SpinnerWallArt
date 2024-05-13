import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Login from './Login';
import Registration from './Registration';
import DashBoard from './Users/DashBoard';
import Orders from './Users/Orders';
import Profile from './Users/Profile';
import ProductDisplay from './Users/ProductDisplay';
import Header from './Users/Header';

import AdminDashBoard from './Admin/AdminDashBoard';
import AdminHeader from './Admin/AdminHeader';
import AdminOrder from './Admin/AdminOrders';
import UserDetails from './Admin/UserDetails';



export default function RouterPage() {
    return (
        <Router>
            <Routes>
                <Route path='/Login' element={<Login />} />
                <Route path='/registration' element={<Registration />} />

                <Route path='/dashboard' element={<DashBoard />} />        
                <Route path='/myorders' element={<Orders />} />
                <Route path='/profile' element={<Profile />} />
                <Route path='/cart' element={<Cart />} />
                <Route path='/products' element={<ProductDisplay />} />
               
                <Route path='/admindashboard' element={<AdminDashBoard />} />               
                <Route path='/adminorders' element={<AdminOrders />} />
                <Route path='/myproducts' element={<AdminProducts />} />
                <Route path='/customers' element={<UserDetails />} />
               
            </Routes>
        </Router>
    )
}