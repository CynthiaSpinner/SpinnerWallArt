import React, {useState, useEffect, useMemo, useCallback} from 'react';
import AdminHeader from "./AdminHeader";
import ProductTable from "./ProductTable";
import '../../StyleSheets/ProductEditForm.css';


export default function AdminProducts() {
    const [adminproducts, setAdminProducts] = useState([{ productID: 0 }])

    const [editProducts, setEditProducts] = useState(false);

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
        <div>
            <section className="background" >
               
                <div className="background">   
                    <AdminHeader></AdminHeader>
                </div>
            
                <ProductTable products={adminproducts} editProducts={editProducts} setEditProducts={setEditProducts}></ProductTable>
            </section>
            <section className="editSection">
                    {editProducts && <div className="editProductPopUp">
                            <div className="editProductContainer">                  
                                <div className="editProducts-FormBody">
                                    <h3 className="editFormHeading">Add or Update Product</h3>
                                    <div htmlFor='editForm'>

                                        <div className="row">

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="productName" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="productName">Product Name</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="available" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="available">Available</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size1" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="size1">Small Size</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price1" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="price1">Small Price</label>
                                                </div>

                                            </div>

                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size2" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="size2">Medium Size</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price2" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="price2">Medium Price</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="size3" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="size3">Large Size</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="price3" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="price3">Large Price</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="quantity" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="quantity">Quantity</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <div data-mdb-input-init className="form">
                                                    <input type="text" id="discount" className="productFormFill"  />
                                                    <label className="productFormLabel" htmlFor="discount">Discount</label>
                                                </div>

                                            </div>
                                            <div className="col">

                                                <input className="file" id="imageUrl" type="file" />
                                                <label htmlFor="formFileSm" className="uploadImg">Upload Image</label>
                                            </div>

                                        </div>

                                        <div className="col">
                                            <button data-mdb-ripple-init className="sub" type="submit" onClick={addAndUpdate} >Submit</button>
                                        </div>

                                    </div>
                                </div>
                            
                            </div>

                    </div>}
            </section>
        </div>
    )
}