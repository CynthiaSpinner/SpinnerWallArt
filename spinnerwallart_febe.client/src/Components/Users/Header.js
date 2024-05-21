import React, { useState } from 'react';
import { Link } from "react-router-dom";
import '../../StyleSheets/Header.css';

export default function Header() {

    const [dropDown, setDropDown] = useState(false);
    const myFunction = () => {
        setDropDown(!dropDown)
    }
    const login = (() => {
        const password = document.getElementById('password').value;
        const email = document.getElementById('email').value;

        fetch('https://localhost:7090/api/Home/Login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Password: password, Email: email, })
        })
            .then(response => response.json()).then((data) => {
                console.log(data)
            })
    })

    return (
        <header className="user-header">
            <div className="user-logo-container">
                <div className="user-logo-title">
                    SpinnerWallArt
                </div>
            </div>
            <div>
                <nav className="user-nav">                
                     <div className="user-nav-container" id="navbarSupportedContent">

                        <ul className="user-nav-ul">
                            <li className="user-nav-item">
                                <Link className="user-nav-item" to='/dashboard' >Home</Link>
                            </li>

                            <li className="user-nav-item">                                    
                                <Link className="user-nav-item" to='/products' >Products</Link>
                            </li>
                            
                            <li className="user-nav-item">
                                <Link className="user-nav-item" to='/cart' >MyCart</Link>
                            </li>

                            <li className="user-nav-item">
                                <Link className="user-nav-item" to='/profile' >Profile</Link>
                            </li>

                            <div className="dropdown">
                                <div onClick={myFunction} className="dropbtn">Login</div>
                               
                                {dropDown && <ul className="user-dropdown-menu">

                                    <li>
                                        <input type="email" id="email" className="user-form-control" placeholder="Email..." />
                                        
                                    </li>

                                    <li><input type="password" id="password" className="user-form-control" placeholder="Password..." />
                                        
                                    </li>
                                    <li className="user-nav-item">
                                        <Link to='/registration' >Register</Link>
                                    </li>
                                    <div className="btn-login">
                                        <button  className="btn" onClick={login} type="button">Login</button>
                                    </div>
                                </ul>}
                                
                            </div>
                            
                        </ul>                          
                        
                    </div>
                </nav>
            </div>
        </header>
    )
}