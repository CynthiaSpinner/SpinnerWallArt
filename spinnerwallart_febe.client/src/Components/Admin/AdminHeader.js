import React from 'react';
import { Link } from "react-router-dom";
import '../../StyleSheets/AdminHeader.css';

export default function AdminHeader() {
    return (
        <section>            
            <nav class="navbar navbar-expand-lg bg-light">
                <div class="container-fluid">
                    
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                        <div class="navbar-nav">
                            <Link to='/AdminDashboard' >Admin Dashboard</Link>
                            <Link to='/adminorders' >Orders</Link>
                            <Link to='/myproducts' >Products</Link>
                            <Link to='/customers' >Customer Details</Link>
                            
                            
                        </div>
                    </div>
                </div>
            </nav>
        </section>   
    )
}