import React from 'react';
import '../../StyleSheets/ProductTable.css';


export default function ProductTable({ products, editProducts,setEditProducts }) {

   

    const popUpEdit = () => {
        setEditProducts(!editProducts)
    }

    const delete1 = (e) => {
        console.log(e);
        const name = e.target.value;
        console.log(name)
        fetch('https://localhost:7090/api/Admin/DeleteProduct', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                productName: name,
                imageUrl: ""

            })
        })
    }


    let keyIndex = 0;

    const tableRows = (product) => { 
        const rowStyleProd = keyIndex % 2 === 0 ? "rowStleProd-Alt" : "rowStyleProd";
        keyIndex++;

        return (
            <tr className={rowStyleProd} key={`tableKey${keyIndex}`}>
                <th id="row-id" scope="row">{product.ProductID}</th>
                <td id="row-PN">{product.ProductName}</td>
                <td id="row-I">{product.ImageUrl}</td>
                <td id="row-S1">{product.Size1}</td>
                <td id="row-P1">{product.Price1}</td>
                <td id="row-S2">{product.Size2}</td>
                <td id="row-P2">{product.Price2}</td>
                <td id="row-S3">{product.Size3}</td>
                <td id="row-P3">{product.Price3}</td>
                <td id="row-A">{product.Available}</td>
                <td id="row-Q">{product.Quantity}</td>
                <td id="row-D">{product.Discount}</td>
                <td id="row-O">
                 
                    <button className="fa-regular fa-pen-to-square" onClick={popUpEdit}></button>
                   
                        <button className="fas fa-trash" value={product.ProductName} type="delete" onClick={delete1}>
                           
                        </button>
                 
                </td>
            </tr>
        )
    }

    return (

        <table className="productTable">
            <thead>
                <tr className = "productTable-Cols">
                    <th id="productId" scope="col">Product ID</th>
                    <th id="productName" scope="col">Product Name</th>
                    <th id="imageUrl" scope="col">ImageUrl</th>
                    <th id="sizeS" scope="col">Size 1</th>
                    <th id="priceS" scope="col">Price</th>
                    <th id="sizeM" scope="col">Size 2</th>
                    <th id="priceM" scope="col">Price</th>
                    <th id="sizeL" scope="col">Size 3</th>
                    <th id="priceL" scope="col">Price</th>
                    <th id="available1" scope="col">Available</th>
                    <th id="quantity1" scope="col">Quantity</th>
                    <th id="discount1" scope="col">Discount</th>
                    <th id="options" scope="col">Options</th>
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