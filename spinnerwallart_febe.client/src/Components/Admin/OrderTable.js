import React from 'react';

export default function OrderTable({ orders, editOrders, setEditOrders }) {

    const popUpEdit = () => {
        setEditOrders(!editOrders)
    }
    
    const delete2 = (e) => {
        console.log(e);
        const name1 = e.target.value;
        console.log(name1)
        fetch('https://localhost:7090/api/Admin/DeleteOrder', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                OrderName: name1,
                imageUrl: ""
    
            })
        })
    }
    
    
    let keyIndex = 0;
    
    const tableRows = (order) => {
        const rowStyleProd = keyIndex % 2 === 0 ? "rowStleOrder-Alt" : "rowStyleOrder";
        keyIndex++;

        return (
             <tr className={rowStyleProd} key={`tableKey${keyIndex}`}>
                <th id="row-OrderId" scope="row">{orders.OrderID}</th>
                <td id="row-ON">{orders.OrderNumber}</td>
                <td id="row-OId">{orders.ID}</td>
                <td id="row-OUser">{orders.UserID}</td>
                <td id="row-OTotal">{orders.OrderTotal}</td>
                <td id="row-OCreated">{orders.OrderCreated}</td>
                <td id="row-OStatus">{orders.OrderStatus}</td>
              
                <td id="row-O2">
                 
                    <button className="fa-regular fa-pen-to-square" onClick={popUpEdit}></button>
                   
                        <button className="fas fa-trash" value={orders.OrderID} type="delete" onClick={delete2}>
                           
                        </button>
                 
                </td>
            </tr>
        )
    }

 return (

        <table className="orderTable">
            <thead>
                <tr className = "orderTable-Cols">
                    <th id="orderID" scope="col">OrderID</th>
                    <th id="orderNumber" scope="col">OrderNumber</th>
                    <th id="oID" scope="col">ID</th>
                    <th id="orderTotal" scope="col">OrderTotal</th>
                    <th id="orderCreated" scope="col">OrderCreated</th>
                    <th id="orderStatus" scope="col">OrderStatus</th>
                    
                    <th id="orderOptions" scope="col">Options</th>
                </tr>
            </thead>
            <tbody>
                {orders?.map((order) => {
                    return tableRows(order)                  
                })}                
            </tbody>
        </table>
    )
}