import React from 'react';
import { Link } from "react-router-dom";
import '../../StyleSheets/AdminHeader.css';

export default function AdminHeader() {
    return (
        <header className="admin-header">
            <div className="admin-logo-container">
                <div className="admin-logo-title">
                    SpinnerWallArt
                </div>
            </div>
            <div>
                <nav className="admin-nav">
                    <div className="admin-nav-container" id="navbarSupportedContent">

                        <ul className="admin-nav-ul">
                            <li className="admin-nav-item">
                                <Link className="admin-nav-item" to='/' >Admin Dashboard</Link>
                            </li>

                            <li className="admin-nav-item">
                                <Link className="admin-nav-item" to='/adminorders' >Orders</Link>
                            </li>

                            <li className="admin-nav-item">
                                <Link className="admin-nav-item" to='/myproducts' >Products</Link>
                            </li>

                            <li className="admin-nav-item">
                                <Link className="admin-nav-item" to='/customers' >Customer Details</Link>
                            </li>


                        </ul>

                    </div>
                </nav>
            </div>
        </header>
    )
}
