import React, { useState, useEffect, useMemo } from 'react';
import AdminHeader from "./AdminHeader";
import UserTable from "./UserTable";
import '../../StyleSheets/UserTable.css';

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
                console.log(data.ListUsers)
                setUserDetails(data.ListUsers)
            })
    }, [])


    return (
        /* GetAllProducts*/

        <section>
            <div>
                <AdminHeader></AdminHeader>
            </div>

            <UserTable users={userDetails}></UserTable>
           
        </section>
    )
}