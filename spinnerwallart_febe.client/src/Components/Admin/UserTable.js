import React from 'react';
import '../../StyleSheets/UserTable.css';


export default function UserTable({ users }) {

    //const delete1 = (e) => {
    //    console.log(e);
    //    const name = e.target.value;
    //    console.log(name)
    //    fetch('https://localhost:7090/api/Admin/DeleteProduct', {
    //        method: 'POST',
    //        headers: { 'Content-Type': 'application/json' },
    //        body: JSON.stringify({
    //            UserName: name,

    //        })
    //    })
    //}
    console.log(users)
    let keyIndex = 0;

    const tableRows = (user) => {
        const rowStyle = keyIndex % 2 === 0 ? "userTable-Rows-Alt" : "userTable-Rows";
        keyIndex++;

        return (
            <tr className={rowStyle} key={`tableKey${keyIndex}`}>
                <th id="row-ID" scope="row">{user.ID}</th>
                <td id="row-FN" >{user.FirstName}</td>
                <td id="row-LN" >{user.LastName}</td>
                <td id="row-P" >{user.Password}</td>
                <td id="row-E" >{user.Email}</td>
                <td id="row-TA" >{user.TotalAmount}</td>
                <td id="row-T" >{user.Type}</td>
                <td id="row-S" >{user.Status}</td>                
                <td id="row-C" >{user.Created}</td>
                <td id="row-O" >
                    <i className="fa-regular fa-pen-to-square"></i>
                    <i className="fas fa-trash"></i>
                </td>
            </tr>
        )
    }

    return (

        <table className="userTable">
            <thead>
                <tr className = "userTable-Cols">
                    <th id="id" scope="col">User ID</th>
                    <th id="firstName" scope="col">First Name</th>
                    <th id="lastName" scope="col">Last Name</th>
                    <th id="password" scope="col">Password</th>                    
                    <th id="email" scope="col">Email</th>
                    <th id="totalAmount" scope="col">Total Amount</th>
                    <th id="type" scope="col">Type</th>
                    <th id="status" scope="col">Status</th>
                    <th id="created" scope="col">Created</th>
                    <th id="user-options" scope="col">Options</th>
                </tr>
            </thead>
            <tbody>
                {users?.map((user) => {
                    return tableRows(user)
                })}
            </tbody>
        </table>
    )

}