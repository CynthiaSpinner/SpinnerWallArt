import React, {useState, useEffect, useMemo, useCallback} from 'react';
import AdminHeader from "./AdminHeader";
import ProductTable from "./ProductTable";
import '../../StyleSheets/Registration.css';


export default function AdminProducts() {
    const [adminproducts, setAdminProducts] = useState([{productID: 0}])

    /*const [imageProduct, setImageProducts] = useState("")*/
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
        const imageUrl = document.getElementById('imageUrl').files;
        const file = imageUrl[0];
        const formData = new FormData();
        formData.append('file', file);

        fetch('https://localhost:7090/api/Admin/SaveFile', {
            method: 'POST', 
            
            body: formData
            
        })
            .then(response => response.json()).then((data) => {
                console.log(data)
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
                        imageUrl: data,
                        available: available
                    })
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
                console.log(data.ListProducts)
                setAdminProducts(data.ListProducts)
            })
    }, [])
    

    
    return (
        /* GetAllProducts*/
      <main className="background">
            <section className="background" >
               
                <div className="background">   
                    <AdminHeader></AdminHeader>
                </div>
            
                <ProductTable products={adminproducts}></ProductTable>
            </section>
            <section className="gradient">
                <div className="container-form">
                    <div className="container2">
                        <div className="col1">
                            <div className="card">
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