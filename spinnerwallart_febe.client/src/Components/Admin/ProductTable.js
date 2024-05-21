import React from 'react';
import '../../StyleSheets/Registration.css';


export default function ProductTable({products}) {

    const delete1 = (e) => {
        console.log(e);
        const name = e.target.value;
        console.log(name)
        fetch('https://localhost:7090/api/Admin/DeleteProduct', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                productName: name,

            })
        })
    }

    let keyIndex = 0;

    const tableRows = (product) => { 
        keyIndex++;
        return (
            <tr key={`tableKey${keyIndex}`}>
                <th scope="row">{product.ProductID}</th>
                <td>{product.ProductName}</td>
                <td>{product.ImageUrl}</td>

                <td>{product.Size1}</td>
                <td>{product.Price1}</td>
                <td>{product.Size2}</td>
                <td>{product.Price2}</td>
                <td>{product.Size3}</td>
                <td>{product.Price3}</td>
                <td>{product.Available}</td>
                <td>{product.Quantity}</td>
                <td>{product.Discount}</td>
                <td>
                    <button value={product.ProductName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                </td>
            </tr>
        )
    }

    

    return (

        <table className="table table-striped">
            <thead>
                <tr>
                    <th id="productid" scope="col">Product ID</th>
                    <th id="productname" scope="col">Product Name</th>
                    <th id="imageurl" scope="col">ImageUrl</th>

                    <th id="sizes" scope="col">Size 1</th>
                    <th id="prices" scope="col">Price</th>

                    <th id="sizem" scope="col">Size 2</th>
                    <th id="pricem" scope="col">Price</th>

                    <th id="sizel" scope="col">Size 3</th>
                    <th id="pricel" scope="col">Price</th>

                    <th id="available1" scope="col">Available</th>
                    <th id="quantity1" scope="col">Quantity</th>

                    <th id="discount1" scope="col">Discount</th>



                </tr>
            </thead>
            <tbody>

                {products?.map((product) => {
                    return tableRows(product)                  
                })}
                
            </tbody>
        </table>
    )
}