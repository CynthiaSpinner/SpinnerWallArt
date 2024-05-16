import React from 'react';
import AdminHeader from "./AdminHeader"

export default function AdminProducts() {

    //fetch('https://localhost:7090/api/ProductsController/GetAllProducts', {
    //    method: 'POST',
    //    headers: { 'Content-Type': 'application/json' },
    //   /* body: JSON.stringify({ Password: password, Email: email, })*/
    //})
    //    .then(response => response.json()).then((data) => {
    //        console.log(data)
    //    })
    return (
        /* GetAllProducts*/
        
        <section>
            <div>   {/*<Link to='/admindashboard' ></Link>*/}
                <AdminHeader></AdminHeader>
            </div>
            <table class="table table-striped table-dark">
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