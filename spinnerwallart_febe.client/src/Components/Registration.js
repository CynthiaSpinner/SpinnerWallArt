import React from 'react';
import '../StyleSheets/Registration.css';

export default function Registration() {
    const registration = (() => {
        const password = document.getElementById('password').value;
        const email = document.getElementById('email').value;
        const firstname = document.getElementById('firstname').value;
        const lastname = document.getElementById('lastname').value;
        
        fetch('https://localhost:7090/api/Home/Register', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Password: password, Email: email, FirstName: firstname, LastName: lastname, })
        })
            //.then(response => response.json()).then((data) => {
            //    console.log(data)
            //})
    })
    return (
        <section className="vh-100 gradient-custom">
            <div className="container py-5 h-100">
                <div className="row justify-content-center align-items-center h-100">
                    <div className="col-12 col-lg-9 col-xl-7">
                        <div className="card shadow-2-strong card-registration">
                            <div className="card-body p-4 p-md-5">
                                <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Registration Form</h3>
                                <div htmlFor='form_element'>

                                    <div className="row">
                                        <div className="col-md-6 mb-4">

                                            <div data-mdb-input-init className="form-outline">
                                                <input type="text" id="firstname" className="form-control form-control-lg" autoComplete="given-name" />
                                                <label className="form-label" htmlFor="firstname">First Name</label>
                                            </div>

                                        </div>
                                        <div className="col-md-6 mb-4">

                                            <div data-mdb-input-init className="form-outline">
                                                <input type="text" id="lastname" className="form-control form-control-lg" autoComplete="given-name" />
                                                <label className="form-label" htmlFor="lastname">Last Name</label>
                                            </div>

                                        </div>
                                    </div>

                                    
                                    <div className="row">
                                        <div className="col-md-6 mb-4 pb-2">

                                            <div data-mdb-input-init className="form-outline">
                                                <input type="email" id="email" className="form-control form-control-lg" autoComplete="given-name" />
                                                <label className="form-label" htmlFor="email">Email</label>
                                            </div>

                                        </div>
                                       
                                    </div>

                                    <div className="row">
                                        <div className="col-md-6 mb-4 pb-2">

                                            <div data-mdb-input-init className="form-outline">
                                                <input type="password" id="password" className="form-control form-control-lg" autoComplete="given-name" />
                                                <label className="form-label" htmlFor="password">Password</label>
                                            </div>

                                        </div>
                                    </div>
                                   

                                    <div className="mt-4 pt-2">
                                        <button data-mdb-ripple-init className="btn btn-primary btn-lg" type="submit" onClick={registration}>Submit</button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    )
}