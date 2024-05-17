import React, {useState, useEffect, useMemo, useCallback} from 'react';
import AdminHeader from "./AdminHeader";
import '../../StyleSheets/Registration.css';


export default function AdminProducts() {
    const [adminproducts, setAdminProducts] = useState([{productID: 0}])


    const addAndUpdate = useCallback(() => {
        const available = document.getElementById('available').value;
        const productName = document.getElementById('productName').value;
        const price1 = document.getElementById('price1').value;
        const price2 = document.getElementById('price2').value;
        const size1 = document.getElementById('size1').value;
        const price3 = document.getElementById('price3').value;
        const size2 = document.getElementById('size2').value;
        const size3 = document.getElementById('size3').value;
        const discount = document.getElementById('discount').value;
        const quantity = document.getElementById('quantity').value;
        const imageUrl = document.getElementById('imageUrl').value;
        const imageName = imageUrl.slice(imageUrl.lastIndexOf('\\')+1, imageUrl.length)
        
        const imageFile = `../../../public/Images/${imageName}`
        console.log(imageName)
        fetch('https://localhost:7090/api/Admin/AddAndUpdateProd', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                productName: productName,
                price1: price1,
                price2: price2,
                price3: price3,
                size1: size1,
                size2: size2,
                size3: size3,
                discount: discount,
                quantity: quantity,
                imageUrl: imageFile,
                available: available
            })
        })
    }  , [])
            
    useEffect(() => {
        console.log(adminproducts)
    },[adminproducts])
    useMemo(() => {
        fetch('https://localhost:7090/api/Products/GetAllProducts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                "productID": 0,
                "productName": "string",
                "price1": 0,
                "price2": 0,
                "price3": 0,
                "size1": "string",
                "size2": "string",
                "size3": "string",
                "discount": 0,
                "quantity": 0,
                "imageUrl": "string",
                "available": 0
            })

        })
            .then(response => response.json()).then((data) => {
                console.log(data.listProducts)
                setAdminProducts(data.listProducts)
            })
    }, [])
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
    
    return (
        /* GetAllProducts*/
      <main className="background">
            <section className="background" >
                <div>

                </div>
                <div className="background">   
                    <AdminHeader></AdminHeader>
                </div>
            
                <table className="table table-striped">
                    <thead>
                        <tr>
                            <th id="productid" scope="col">Product ID</th>
                            <th id="productname" scope="col">Product Name</th>
                            <th id="imageurl" scope="col">ImageUrl</th>

                            <th id="size1" scope="col">Size 1</th>
                            <th id="price1" scope="col">Price</th>

                            <th id="size2" scope="col">Size 2</th>
                            <th id="price2" scope="col">Price</th>

                            <th id="size3" scope="col">Size 3</th>
                            <th id="price3" scope="col">Price</th>

                            <th id="available" scope="col">Available</th>
                            <th id="quantity" scope="col">Quantity</th>
                            
                            <th id="discount" scope="col">Discount</th>
                            
                            
                            
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <th scope="row">{adminproducts[0]?.productID}</th>
                            <td>{adminproducts[0]?.productName}</td>
                            <td>{adminproducts[0]?.imageUrl}</td>
                           
                            <td>{adminproducts[0]?.size1}</td>
                            <td>{adminproducts[0]?.price1}</td>
                            <td>{adminproducts[0]?.size2}</td>
                            <td>{adminproducts[0]?.price2}</td>
                            <td>{adminproducts[0]?.size3}</td>
                            <td>{adminproducts[0]?.price3}</td>
                            <td>{adminproducts[0]?.available}</td>
                            <td>{adminproducts[0]?.quantity}</td>
                            <td>{adminproducts[0]?.discount}</td>
                            <td>
                                <button value={adminproducts[0]?.productName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                            </td>
                            
                        </tr>
                        <tr>
                            <th scope="row">{adminproducts[1]?.productID}</th>
                            <td>{adminproducts[2]?.productName}</td>
                            <td>{adminproducts[1]?.imageUrl}</td>
                            
                            <td>{adminproducts[1]?.size1}</td>
                            <td>{adminproducts[1]?.price1}</td>
                            <td>{adminproducts[1]?.size2}</td>
                            <td>{adminproducts[1]?.price2}</td>
                            <td>{adminproducts[1]?.size3}</td>
                            <td>{adminproducts[1]?.price3}</td>
                            <td>{adminproducts[1]?.available}</td>
                            <td>{adminproducts[1]?.quantity}</td>
                            <td>{adminproducts[1]?.discount}</td>
                            <td>
                                <button value={adminproducts[0]?.productName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">{adminproducts[2]?.productID}</th>
                            <td>{adminproducts[2]?.productName}</td>
                            <td>{adminproducts[2]?.imageUrl}</td>
                            
                            <td>{adminproducts[2]?.size1}</td>
                            <td>{adminproducts[2]?.price1}</td>
                            <td>{adminproducts[2]?.size2}</td>
                            <td>{adminproducts[2]?.price2}</td>
                            <td>{adminproducts[2]?.size3}</td>
                            <td>{adminproducts[2]?.price3}</td>
                            <td>{adminproducts[2]?.available}</td>
                            <td>{adminproducts[2]?.quantity}</td>
                            <td>{adminproducts[2]?.discount}</td>
                            <td>
                                <button value={adminproducts[0]?.productName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">{adminproducts[3]?.productID}</th>
                            <td>{adminproducts[3]?.productName}</td>
                            <td>{adminproducts[3]?.imageUrl}</td>
                            
                            <td>{adminproducts[3]?.size1}</td>
                            <td>{adminproducts[3]?.price1}</td>
                            <td>{adminproducts[3]?.size2}</td>
                            <td>{adminproducts[3]?.price2}</td>
                            <td>{adminproducts[3]?.size3}</td>
                            <td>{adminproducts[3]?.price3}</td>
                            <td>{adminproducts[3]?.available}</td>
                            <td>{adminproducts[3]?.quantity}</td>
                            <td>{adminproducts[3]?.discount}</td>
                            <td>
                                <button value={adminproducts[0]?.productName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                            </td>
                        </tr>
                        <tr>
                            <th scope="row">{adminproducts[4]?.productID}</th>
                            <td>{adminproducts[4]?.productName}</td>
                            <td>{adminproducts[4]?.imageUrl}</td>
                           
                            <td>{adminproducts[4]?.size1}</td>
                            <td>{adminproducts[4]?.price1}</td>
                            <td>{adminproducts[4]?.size2}</td>
                            <td>{adminproducts[4]?.price2}</td>
                            <td>{adminproducts[4]?.size3}</td>
                            <td>{adminproducts[4]?.price3}</td>
                            <td>{adminproducts[4]?.available}</td>
                            <td>{adminproducts[4]?.quantity}</td>
                            <td>{adminproducts[4]?.discount}</td>
                            <td>
                                <button value={adminproducts[0]?.productName} className="delete-button" type="delete" onClick={delete1} >Delete</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
        </section>
            <section className="gradient">
                <div className="container-form">
                    <div className="container2">
                        <div className="col1">
                            <div className="card shadow-2-strong card-registration">
                                <div className="card-body">
                                    <h3 className="mb-4 pb-2 pb-md-0 mb-md-5">Add or Update Product</h3>
                                    <div htmlFor='form_element'>

                                        <div className="row">
                                           
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="productName" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="productName">Product Name</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="available" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="available">Available</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size1" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="size1">Small Size</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price1" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="price1">Small Price</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size2" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="size2">Medium Size</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price2" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="price2">Medium Price</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size3" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="size3">Large Size</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price3" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="price3">Large Price</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="quantity" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="quantity">Quantity</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="discount" className="form-control form-control-lg" autoComplete="given-name" />
                                                    <label className="form-label" htmlFor="discount">Discount</label>
                                                </div>

                                            </div>
                                            <div className="col">
                                               
                                                <input className="file" id="imageUrl" type="file" />
                                                <label htmlFor="formFileSm" className="slabel">Upload Image</label>
                                            </div>
                                            
                                        </div>


                                        



                                       
                                        

                                        <div className="mt-4 pt-2">
                                            <button data-mdb-ripple-init className="sub" type="submit" onClick={addAndUpdate} >Submit</button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                
        </section>
      </main>
    )
}