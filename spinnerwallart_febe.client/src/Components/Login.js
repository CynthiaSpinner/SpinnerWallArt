
import React from 'react';
import '../StyleSheets/Login.css';

export default function Login() {
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
        <section className="vh-100">
            <div className="container py-5 h-100">
                <div className="row d-flex justify-content-center align-items-center h-100">
                    <div className="col col-xl-10">
                        <div className="card">
                            <div className="row g-0">
                                {/*<div className="col-md-6 col-lg-5 d-none d-md-block">*/}
                                {/*    */}{/*<img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp"*/}
                                {/*    */}{/*    alt="login form" className="img-fluid"/>*/}
                                {/*</div>*/}
                                <div className="col-md-6 col-lg-7 d-flex align-items-center">
                                    <div className="card-body p-4 p-lg-5 text-black">

                                        <form>

                                            <div className="d-flex align-items-center mb-3 pb-1">
                                                <i className="fas fa-cubes fa-2x me-3"></i>
                                                <span className="h1 fw-bold mb-0">Logo</span>
                                            </div>

                                            <h5 className="fw-normal mb-3 pb-3">Sign into your account</h5>

                                            <div data-mdb-input-init className="form-outline mb-4">
                                                <input type="email" id="email" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form2Example17">Email address</label>
                                            </div>

                                            <div data-mdb-input-init className="form-outline mb-4">
                                                <input type="password" id="password" className="form-control form-control-lg" />
                                                <label className="form-label" htmlFor="form2Example27">Password</label>
                                            </div>

                                            <div className="pt-1 mb-4">
                                                <button data-mdb-button-init data-mdb-ripple-init className="btn btn-dark btn-lg btn-block" onClick={login} type="button">Login</button>
                                            </div>

                                            <a className="small text-muted" href="#!">Forgot password?</a>
                                            <p className="mb-5 pb-lg-2">Don't have an account? <a href="#!">Register here</a></p>
                                            <a href="#!" className="small text-muted">Terms of use.</a>
                                            <a href="#!" className="small text-muted">Privacy policy</a>
                                        </form>

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
