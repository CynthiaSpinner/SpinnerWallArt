import React, { useState, useEffect, useMemo, useCallback } from 'react';
import AdminHeader from "./AdminHeader";
import OrderTable from "./OrderTable";


export default function AdminOrders() {
    const [adminOrders, setAdminOrders] = useState([{ productID: 0 }])

    const [editOrders, setEditOrders] = useState(false);

    const refresh = useCallback(() => {
        fetch('https://localhost:7090/api/Products/OrderList', {
            method: 'GET',
            headers: { 'Content-Type': 'application/json' },


        })
            .then(response => response.json()).then((data) => {
                console.log(data.ListOrders)
                setAdminOrders(data.ListOrders)
            })
    }, [])
    return (
        <section>
            <div>   {/*<Link to='/admindashboard' ></Link>*/}
               <AdminHeader></AdminHeader>
            </div> 
            <OrderTable orders={adminOrders} editorders={editOrders} setEditOrders={setEditOrders}></OrderTable>
           
        </section>
    )
}