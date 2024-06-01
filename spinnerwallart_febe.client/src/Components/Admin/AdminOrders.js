import React, { useState, useEffect, useMemo, useCallback } from 'react';
import AdminHeader from "./AdminHeader";
import OrderTable from "./OrderTable";


export default function AdminOrders() {
    const [adminOrders, setAdminOrders] = useState([{ productID: 0 }])

    const [editOrders, setEditOrders] = useState(false);

    const refresh = useCallback(() => {
        fetch('https://localhost:7090/api/Admin/GetAllProducts', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },


        })
            .then(response => response.json()).then((data) => {
                console.log(data.ListProducts)
                setAdminProducts(data.ListProducts)
            })
    }, [])
    return (
        <section>
            <div>   {/*<Link to='/admindashboard' ></Link>*/}
               <AdminHeader></AdminHeader>
            </div> 
            <table className="table table-striped table-dark">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">First</th>
                        <th scope="col">Last</th>
                        <th scope="col">Handle</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td>Larry</td>
                        <td>the Bird</td>
                        <td>@twitter</td>
                    </tr>
                </tbody>
            </table>
        </section>
    )
}