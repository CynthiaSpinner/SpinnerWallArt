import React from 'react';
import { Link } from "react-router-dom";
import '../../StyleSheets/AdminHeader.css';

export default function AdminHeader() {
    return (
        <header>
            <div className="logo-title">
            SpinnerWallArt
            </div>
            <nav className="navbar">
                <div className="container">
                    
                    {/*<button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">*/}
                    {/*    <span className="navbar-toggler-icon"></span>*/}
                    {/*</button>*/}
                    <div className="link-container">
                        <div className="navbar-size">
                            <Link to='/AdminDashboard' >Admin Dashboard</Link>
                            <Link to='/adminorders' >Orders</Link>
                            <Link to='/myproducts' >Products</Link>
                            <Link to='/customers' >Customer Details</Link>
                            
                            
                        </div>
                    </div>
                </div>
            </nav>
        </header>   
    )
}