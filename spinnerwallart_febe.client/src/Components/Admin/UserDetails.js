import React, { useState, useEffect, useMemo } from 'react';
import AdminHeader from "./AdminHeader";
import '../../StyleSheets/Registration.css';

export default function UserDetails() {

    const [userDetails, setUserDetails] = useState([{ ID: 0 }])
    useEffect(() => {
        console.log(userDetails)
    }, [userDetails])
    useMemo(() => {
        fetch('https://localhost:7090/api/Admin/GetAllUsers', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' }
            
            

        })
            .then(response => response.json()).then((data) => {
                console.log(data.listUsers)
                setUserDetails(data.listUsers)
            })
    }, [])


    return (
        /* GetAllProducts*/
        
            <section>
                <div>
                    <AdminHeader></AdminHeader>
                </div>

                <table className="table table-striped table-dark">
                    <thead>
                        <tr>
                        <th id="firstName" scope="col">firstName</th>
                        <th id="lastName" scope="col">lastName</th>
                        <th id="password" scope="col">password</th>

                        <th id="id" scope="col">id</th>
                        <th id="email" scope="col">email</th>

                        <th id="totalAmount" scope="col">totalAmount</th>
                        <th id="type" scope="col">type</th>

                        <th id="status" scope="col">status</th>
                        <th id="created" scope="col">created</th>

                            



                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">{userDetails[0]?.id}</th>
                            <td>{userDetails[0]?.firstName}</td>
                            <td>{userDetails[0]?.lastName}</td>

                            <td>{userDetails[0]?.password}</td>
                            <td>{userDetails[0]?.email}</td>
                            <td>{userDetails[0]?.type}</td>
                            <td>{userDetails[0]?.status}</td>
                            <td>{userDetails[0]?.totalAmount}</td>
                            <td>{userDetails[0]?.created}</td>
                            
                        </tr>
                        <tr>
                            <th scope="row">{userDetails[1]?.id}</th>
                            <td>{userDetails[1]?.firstName}</td>
                            <td>{userDetails[1]?.lastName}</td>

                            <td>{userDetails[1]?.password}</td>
                            <td>{userDetails[1]?.email}</td>
                            <td>{userDetails[1]?.type}</td>
                            <td>{userDetails[1]?.status}</td>
                            <td>{userDetails[1]?.totalAmount}</td>
                            <td>{userDetails[1]?.created}</td>

                        </tr>
                        <tr>
                            <th scope="row">{userDetails[2]?.id}</th>
                            <td>{userDetails[2]?.firstName}</td>
                            <td>{userDetails[2]?.lastName}</td>

                            <td>{userDetails[2]?.password}</td>
                            <td>{userDetails[2]?.email}</td>
                            <td>{userDetails[2]?.type}</td>
                            <td>{userDetails[2]?.status}</td>
                            <td>{userDetails[2]?.totalAmount}</td>
                            <td>{userDetails[2]?.created}</td>
                            
                        </tr>
                        <tr>
                            <th scope="row">{userDetails[3]?.id}</th>
                            <td>{userDetails[3]?.firstName}</td>
                            <td>{userDetails[3]?.lastName}</td>

                            <td>{userDetails[3]?.password}</td>
                            <td>{userDetails[3]?.email}</td>
                            <td>{userDetails[3]?.type}</td>
                            <td>{userDetails[3]?.status}</td>
                            <td>{userDetails[3]?.totalAmount}</td>
                            <td>{userDetails[3]?.created}</td>

                        </tr>
                        <tr>
                            <th scope="row">{userDetails[4]?.id}</th>
                            <td>{userDetails[4]?.firstName}</td>
                            <td>{userDetails[4]?.lastName}</td>

                            <td>{userDetails[4]?.password}</td>
                            <td>{userDetails[4]?.email}</td>
                            <td>{userDetails[4]?.type}</td>
                            <td>{userDetails[4]?.status}</td>
                            <td>{userDetails[4]?.totalAmount}</td>
                            <td>{userDetails[4]?.created}</td>

                        </tr>
                    </tbody>
                </table>
            </section>
    )
}